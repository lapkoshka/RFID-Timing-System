using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace Core
{
    public abstract class DeviceManagerBase
    {
        public event EventHandler<TagCatchEventArgs> TagCatchHandle;
        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusHandle;
        public const int MaxSearchAttempts = 5;
        public const int MaxConnectAttempts = 5;
        public bool ShouldListenReader = true;
        public abstract DeviceType deviceType { get; }

        public void StartConnection()
        {
            ThreadPool.QueueUserWorkItem(SearchAndConnect);
        }

        public abstract void SearchAndConnect(Object StateInfo);

        public void StartListening()
        {
            ThreadPool.QueueUserWorkItem(ListenReader);
        }

        public abstract void ListenReader(Object StateInfo);

        public abstract void DispatchStatus(DeviceStatus status);

        protected void TagCatch(TagCatchEventArgs e)
        {
            TagCatchHandle(this, e);
        }

        protected void ConnectionStatus(ConnectionStatusEventArgs e)
        {
            ConnectionStatusHandle(this, e);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RFIDTag
    {
        public byte PacketParam;
        public byte LEN;
        public string UID;
        public byte RSSI;
        public byte ANT;
        public Int32 Handles;
    }

    public enum DeviceType : uint
    {
        OTHER = 0x01,
        MAIN = 0x02,
        PORTABLE = 0x03
    }

    public enum DeviceStatus : uint
    {
        SEARCHING = 0x01,
        NOT_FOUND = 0x02,
        FOUND = 0x03,
        TRYING_CONNECT = 0x04,
        CONNECTED = 0x05,
        NOT_CONNECTED = 0x06
    }
}
