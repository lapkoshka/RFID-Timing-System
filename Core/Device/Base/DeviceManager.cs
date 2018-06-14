using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Core
{
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
        [Description("Searching...")]
        SEARCHING = 0x01,

        [Description("Reader does not found")]
        NOT_FOUND = 0x02,

        [Description("Reader found")]
        FOUND = 0x03,

        [Description("Trying connect to reader...")]
        TRYING_CONNECT = 0x04,

        [Description("Connected")]
        CONNECTED = 0x05,

        [Description("Does not connected to reader")]
        NOT_CONNECTED = 0x06
    }

    public abstract class DeviceManagerBase
    {
        public event EventHandler<TagCatchEventArgs> TagCatchHandle;
        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusHandle;
        public const int MaxSearchAttempts = 5;
        public const int MaxConnectAttempts = 5;
        public bool ShouldListenReader = true;
        public abstract DeviceType DeviceType { get; }

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
            if (TagCatchHandle != null)
            {
                TagCatchHandle(this, e);
            }
        }

        protected void ConnectionStatus(ConnectionStatusEventArgs e)
        {
            if (ConnectionStatusHandle != null)
            {
                ConnectionStatusHandle(this, e);
            }
        }
    }
}
