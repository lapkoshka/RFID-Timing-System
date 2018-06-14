using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using UHF;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Core
{
    public class MainReader : DeviceManagerBase
    {
        private DeviceType _deviceType = DeviceType.MAIN;
        public override DeviceType DeviceType
        {
            get { return _deviceType; }
        }

        private uint Ip = 0;
        private static IntPtr oldWndProc = IntPtr.Zero;
        private RFIDCallBack delegateRFIDCallBack;

        public override void SearchAndConnect(Object StateInfo)
        {
            //TODO: Change Console.WriteLine to WriteLog.
            bool IsFound = false;
            int SearchAttempts = MaxSearchAttempts;
            while (!IsFound && SearchAttempts > 0)
            {
                DispatchStatus(DeviceStatus.SEARCHING);
                IsFound = StartBroadcast();
                SearchAttempts--;
            }

            if (!IsFound)
            {
                DispatchStatus(DeviceStatus.NOT_FOUND);
                return;
            }

            DispatchStatus(DeviceStatus.FOUND);
            bool IsConnected = false;
            int ConnectAttempts = MaxConnectAttempts;
            while (!IsConnected && ConnectAttempts > 0)
            {
                DispatchStatus(DeviceStatus.TRYING_CONNECT);
                IsConnected = Connect();
                ConnectAttempts--;
            }
            DeviceStatus status = IsConnected ? DeviceStatus.CONNECTED : DeviceStatus.NOT_CONNECTED;
            DispatchStatus(status);
        }

        public override void DispatchStatus(DeviceStatus status)
        {
            ConnectionStatus(new ConnectionStatusEventArgs() {
                Status = status, Ip = this.Ip, Type = this.DeviceType
            });
        }

        private bool StartBroadcast()
        {
            DevControl.tagErrorCode InitErrorCode = DevControl.
                DM_Init(new SearchCallBack(SearchHandler), IntPtr.Zero);

            uint BroadcastIp = 0xffffffff;
            int Timeout = 1500;
            DevControl.tagErrorCode SearchErrorCode = DevControl
                .DM_SearchDevice(BroadcastIp, Timeout);

            return SearchErrorCode == DevControl.tagErrorCode.
                DM_ERR_OK ? true : false;
        }

        private void SearchHandler(IntPtr Dev, IntPtr Data)
        {
            StringBuilder DevName = new StringBuilder(100);
            StringBuilder MacAdd = new StringBuilder(100);
            DevControl.tagErrorCode eCode = DevControl.
                DM_GetDeviceInfo(Dev, ref this.Ip, MacAdd, DevName);
        }

        private bool Connect()
        {
            string ipAddress = IPAddress.Parse(this.Ip.ToString()).ToString();
            int nPort = 27011;
            byte fComAdr = 255;
            int FrmPortIndex = 0;
            int fCmdRet = RWDev.
                OpenNetPort(nPort, ipAddress, ref fComAdr, ref FrmPortIndex);
            if (fCmdRet == 0)
            {
                delegateRFIDCallBack = new RFIDCallBack(RFIDTagCallback);
                RWDev.InitRFIDCallBack(delegateRFIDCallBack, true, FrmPortIndex);
                return true;
            }
            else
            {
                Console.Write(GetErrorCodeDesc(fCmdRet));
                return false;
            }
        }

        protected virtual void RFIDTagCallback(IntPtr p, Int32 nEvt)
        {
            RFIDTag rfidTag = (RFIDTag)Marshal.PtrToStructure(p, typeof(RFIDTag));
            TagCatch(new TagCatchEventArgs() { Tag = rfidTag });
        }

        public override void ListenReader(Object StateInfo)
        {
            while (this.ShouldListenReader)
            {
                byte fComAdr = 0;
                // Multiply query parameters.
                byte Qvalue = 4;
                byte Session = 255;

                byte MaskMem = 0;
                byte[] MaskAdr = new byte[2];
                byte MaskLen = 0;
                byte[] MaskData = new byte[100];
                byte MaskFlag = 0;
                byte AdrTID = 0;
                byte LenTID = 6;
                byte TIDFlag = 0;
                byte Target = 0;
                byte InAnt = 0x80;
                byte Scantime = 20;
                byte FastFlag = 0;
                byte[] EPC = new byte[50000];
                byte Ant = 0;
                int Totallen = 0;
                int TagNum = 0;

                int frmcomportindex = 1;

                int fCmdRet = RWDev.Inventory_G2(
                    ref fComAdr,
                    Qvalue,
                    Session,
                    MaskMem,
                    MaskAdr,
                    MaskLen,
                    MaskData,
                    MaskFlag,
                    AdrTID,
                    LenTID,
                    TIDFlag,
                    Target,
                    InAnt,
                    Scantime,
                    FastFlag,
                    EPC,
                    ref Ant,
                    ref Totallen,
                    ref TagNum,
                    frmcomportindex
                );

                Thread.Sleep(5);
            }
        }

        private string GetErrorCodeDesc(int code)
        {
            switch (code)
            {
                case 0x00:
                case 0x26:
                    return "success";
                case 0x01:
                    return "Return before Inventory finished";
                case 0x02:
                    return "the Inventory-scan-time overflow";
                case 0x03:
                    return "More Data";
                case 0x04:
                    return "Reader module MCU is Full";
                case 0x05:
                    return "Access Password Error";
                case 0x09:
                    return "Destroy Password Error";
                case 0x0a:
                    return "Destroy Password Error Cannot be Zero";
                case 0x0b:
                    return "Tag Not Support the command";
                case 0x0c:
                    return "Use the commmand,Access Password Cannot be Zero";
                case 0x0d:
                    return "Tag is protected,cannot set it again";
                case 0x0e:
                    return "Tag is unprotected,no need to reset it";
                case 0x10:
                    return "There is some locked bytes,write fail";
                case 0x11:
                    return "can not lock it";
                case 0x12:
                    return "is locked,cannot lock it again";
                case 0x13:
                    return "Parameter Save Fail,Can Use Before Power";
                case 0x14:
                    return "Cannot adjust";
                case 0x15:
                    return "Return before Inventory finished";
                case 0x16:
                    return "Inventory-Scan-Time overflow";
                case 0x17:
                    return "More Data";
                case 0x18:
                    return "Reader module MCU is full";
                case 0x19:
                    return "'Not Support Command Or AccessPassword Cannot be Zero";
                case 0x1A:
                    return "Tag custom function error";
                case 0xF8:
                    return "Check antenna error";
                case 0xF9:
                    return "Command execute error";
                case 0xFA:
                    return "Get Tag,Poor Communication,Inoperable";
                case 0xFB:
                    return "No Tag Operable";
                case 0xFC:
                    return "Tag Return ErrorCode";
                case 0xFD:
                    return "Command length wrong";
                case 0xFE:
                    return "Illegal command";
                case 0xFF:
                    return "Parameter Error";
                case 0x30:
                    return "Communication error";
                case 0x31:
                    return "CRC checksummat error";
                case 0x32:
                    return "Return data length error";
                case 0x33:
                    return "Communication busy";
                case 0x34:
                    return "Busy,command is being executed";
                case 0x35:
                    return "ComPort Opened";
                case 0x36:
                    return "ComPort Closed";
                case 0x37:
                    return "Invalid Handle";
                case 0x38:
                    return "Invalid Port";
                case 0xEE:
                    return "Return Command Error";
                default:
                    return "";
            }
        }
    }
}

