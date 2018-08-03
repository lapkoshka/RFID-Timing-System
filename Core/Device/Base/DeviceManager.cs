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
        public DeviceStatus Status { get; protected set; }

        public uint Ip { get; protected set; }

        public DeviceType TypeDevice { get; protected set; }

        public void StartListening()
        {
            SetStatus(DeviceStatus.Listening);
            shouldListenReader = true;
            ListenReader();
        }

        public abstract void ListenReader();

        public void StopListening()
        {
            SetStatus(DeviceStatus.Connected);
            shouldListenReader = false;
            ListenReader();
        }

        public abstract void SetStatus(DeviceStatus status);

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
