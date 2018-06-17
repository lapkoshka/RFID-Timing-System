using System;
using System.Runtime.InteropServices;
using Core.Interfaces;

namespace Core
{
    public abstract class DeviceManagerBase : IDeviceManagerEvents
    {
        public abstract event ConnectionStatusDelegate ConnectionStatusEvent;
        public abstract event TagCatchDelegate TagCatchEvent;

        public readonly int maxSearchAttempts = 5;
        public readonly int maxConnectAttempts = 5;
        public bool shouldListenReader = true;

        public uint Ip { get; protected set; }

        public DeviceType TypeDevice { get; protected set; }

        public abstract void StartListening();

        public abstract void DispatchStatus(DeviceStatus status);

        public abstract void StartConnecting();
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
}
