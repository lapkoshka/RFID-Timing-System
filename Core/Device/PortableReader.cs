using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UHF;
using System.Threading;
using System.Diagnostics;

namespace Core
{

    public enum BaudRate : byte
    {
        BPS_9600 = 0,
        BPS_19200 = 1,
        BPS_38400 = 2,
        BPS_57600 = 3,
        BPS_115200 = 4
    }

    public class PortableReader : DeviceManagerBase
    {
        private DeviceType _deviceType = DeviceType.PORTABLE;
        public override DeviceType DeviceType
        {
            get { return _deviceType; }
        }

        private byte ComAdr = 255;
        private int ComPortIndex = 0;

        public override void SearchAndConnect(Object StateInfo)
        {
            DispatchStatus(DeviceStatus.SEARCHING);

            int port = 0;
            //Как мне использовать говорящие значения из енама?
            byte BaudRate = 5;//(byte)BaudRate.BPS_57600
            int OpenResult = ReaderB.StaticClassReaderB.AutoOpenComPort(
                ref port, ref ComAdr, BaudRate, ref ComPortIndex);
            DeviceStatus status = OpenResult == 0 ?
                DeviceStatus.CONNECTED : DeviceStatus.NOT_FOUND;

            //TODO: 
            //fCmdRet = StaticClassReaderB.GetReaderInformation(ref fComAdr, VersionInfo, ref ReaderType, TrType, ref dmaxfre, ref dminfre, ref powerdBm, ref ScanTime, frmcomportindex);
            DispatchStatus(status);
        }

        public override void ListenReader(Object StateInfo)
        {
            while (this.ShouldListenReader)
            {
                byte AdrTID = 0;
                byte LenTID = 0;
                byte TIDFlag = 0;
                byte[] EPC = new byte[5000];
                int TotalLen = 0;
                int CardNum = 0;
                int InventoryResponse = ReaderB.StaticClassReaderB.Inventory_G2(
                    ref ComAdr, AdrTID, LenTID, TIDFlag, EPC, ref TotalLen, ref CardNum, ComPortIndex);
                if (InventoryResponse == 1)
                {
                    RFIDTag tag = BuildEPCTagFromBytes(TotalLen, EPC);
                    TagCatch(new TagCatchEventArgs() { Tag = tag });
                }

                //TODO: throttler
                Thread.Sleep(1000);
            }
        }

        private RFIDTag BuildEPCTagFromBytes(int TotalLen, byte[] EPC)
        {
            byte[] daw = new byte[TotalLen];
            Array.Copy(EPC, daw, TotalLen);
            string sEPC = ByteArrayToHexString(daw).Substring(0 * 2 + 2, daw[0] * 2);
            return new RFIDTag() { UID = sEPC };
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

        public override void DispatchStatus(DeviceStatus status)
        {
            ConnectionStatus(new ConnectionStatusEventArgs()
            {
                Status = status,
                ComPort = "TODO: COM PORT",
                Type = this.DeviceType
            });
        }
    }
}
