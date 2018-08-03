using System;
using System.Threading;
using Core.Interfaces;
using Core.Helpers;
using System.Threading.Tasks;

namespace Core
{
    public class PortableReader : DeviceManagerBase
    {
        public override event ConnectionStatusDelegate ConnectionStatusEvent;
        public override event TagCatchDelegate TagCatchEvent;
        private byte _comAdr = 255;
        private int _comPortIndex = 0;
        private readonly int _defaultThreadSleepTime = 5;

        public PortableReader()
        {
            TypeDevice = DeviceType.PORTABLE;
        }

        public override void StartConnecting()
        {
            Task.Factory.StartNew(() =>
            {
                SetStatus(DeviceStatus.Searching);

                int port = 0;
                //Как мне использовать говорящие значения из енама?
                byte BaudRate = 5;//(byte)BaudRate.BPS_57600
                int OpenResult = ReaderB.StaticClassReaderB.AutoOpenComPort(ref port, ref _comAdr, BaudRate, ref _comPortIndex);
                DeviceStatus status = OpenResult == 0 ? DeviceStatus.Connected : DeviceStatus.NotFound;
                //fCmdRet = StaticClassReaderB.GetReaderInformation(ref fComAdr, VersionInfo, ref ReaderType, TrType, ref dmaxfre, ref dminfre, ref powerdBm, ref ScanTime, frmcomportindex);
                SetStatus(status);
            });
        }

        public override void ListenReader()
        {
            Task.Factory.StartNew(() =>
            {
                while (shouldListenReader)
                {
                    int sleepTime = _defaultThreadSleepTime;
                    byte AdrTID = 0;
                    byte LenTID = 0;
                    byte TIDFlag = 0;
                    byte[] EPC = new byte[5000];
                    int TotalLen = 0;
                    int CardNum = 0;
                    int InventoryResponse = ReaderB.StaticClassReaderB.Inventory_G2(ref _comAdr, AdrTID, LenTID, TIDFlag, EPC, ref TotalLen, ref CardNum, _comPortIndex);
                    if (InventoryResponse == 1)
                    {
                        RFIDTag tag = BuildEPCTagFromBytes(TotalLen, EPC);
                        TagCatchEvent?.Invoke(new TagCatchEventArgs
                        {
                            Tag = tag
                        });
                        sleepTime = 2000;
                    }
                    Thread.Sleep(sleepTime);
                }
            });
        }

        private RFIDTag BuildEPCTagFromBytes(int TotalLen, byte[] EPC)
        {
            byte[] daw = new byte[TotalLen];
            Array.Copy(EPC, daw, TotalLen);
            string sEPC = daw.ToHexString().Substring(0 * 2 + 2, daw[0] * 2);
            return new RFIDTag() { UID = sEPC };
        }

        public override void SetStatus(DeviceStatus status)
        {
            Status = status;
            ConnectionStatusEvent?.Invoke(new ConnectionStatusEventArgs
            {
                Status = status,
                //TODO: ComPortAddress
                ComPort = "Unknown",
                Type = TypeDevice
            });
        }
    }
}
