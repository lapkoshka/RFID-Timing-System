using System;
using System.Text;
using System.Threading;
using System.Net;
using UHF;
using System.Runtime.InteropServices;
using Core.Interfaces;
using Core.Helpers;
using System.Threading.Tasks;

namespace Core
{
    public class MainReader : DeviceManagerBase
    {
        public override event ConnectionStatusDelegate ConnectionStatusEvent;
        public override event TagCatchDelegate TagCatchEvent;
        private RFIDCallBack _delegateRFIDCallBack;

        public MainReader()
        {
            TypeDevice = DeviceType.MAIN;
        }

        public override void StartConnecting()
        {
            Task.Factory.StartNew(() =>
            {
                bool IsFound = false;
                int SearchAttempts = maxSearchAttempts;
                while (!IsFound && SearchAttempts > 0)
                {
                    DispatchStatus(DeviceStatus.Searching);
                    IsFound = StartBroadcast();
                    SearchAttempts--;
                }

                if (!IsFound)
                {
                    DispatchStatus(DeviceStatus.NotFound);
                    return;
                }

                DispatchStatus(DeviceStatus.Found);
                bool IsConnected = false;
                int ConnectAttempts = maxConnectAttempts;
                while (!IsConnected && ConnectAttempts > 0)
                {
                    DispatchStatus(DeviceStatus.TryingConnect);
                    IsConnected = Connect();
                    ConnectAttempts--;
                }
                DeviceStatus status = IsConnected ? DeviceStatus.Connected : DeviceStatus.NotConnected;
                DispatchStatus(status);
            });
        }

        public override void StartListening()
        {
            Task.Factory.StartNew(() =>
            {
                while (shouldListenReader)
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
            });        
        }

        public override void DispatchStatus(DeviceStatus status)
        {
            ConnectionStatusEvent?.Invoke(new ConnectionStatusEventArgs()
            {
                Status = status,
                Ip = Ip,
                Type = TypeDevice
            });
        }

        private bool StartBroadcast()
        {
            uint broadcastIp = 0xffffffff;
            int timeout = 1500;

            DevControl.tagErrorCode InitErrorCode = DevControl.DM_Init(new SearchCallBack(SearchHandler), IntPtr.Zero);
            DevControl.tagErrorCode SearchErrorCode = DevControl.DM_SearchDevice(broadcastIp, timeout);

            return SearchErrorCode == DevControl.tagErrorCode.DM_ERR_OK ? true : false;
        }

        private void SearchHandler(IntPtr Dev, IntPtr Data)
        {
            uint ip = 0;
            StringBuilder DevName = new StringBuilder(100);
            StringBuilder MacAdd = new StringBuilder(100);
            DevControl.tagErrorCode eCode = DevControl.DM_GetDeviceInfo(Dev, ref ip, MacAdd, DevName);
            Ip = ip;
        }

        private bool Connect()
        {
            string ipAddress = IPAddress.Parse(Ip.ToString()).ToString();
            int nPort = 27011;
            byte fComAdr = 255;
            int frmPortIndex = 0;
            var fCmdRet = (ErrorCode)RWDev.OpenNetPort(nPort, ipAddress, ref fComAdr, ref frmPortIndex);
            if (fCmdRet == ErrorCode.Success)
            {
                _delegateRFIDCallBack = new RFIDCallBack(RFIDTagCallback);
                RWDev.InitRFIDCallBack(_delegateRFIDCallBack, true, frmPortIndex);
                return true;
            }
            else
            {
                Console.Write(fCmdRet.GetDescription());
                return false;
            }
        }

        protected virtual void RFIDTagCallback(IntPtr p, Int32 nEvt)
        {
            RFIDTag rfidTag = (RFIDTag)Marshal.PtrToStructure(p, typeof(RFIDTag));
            TagCatchEvent?.Invoke(new TagCatchEventArgs
            {
                Tag = rfidTag
            });
        }
    }
}

