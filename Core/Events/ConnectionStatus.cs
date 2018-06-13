using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHF;
using System.Net;

namespace Core
{
    public class ConnectionStatusEventArgs : EventArgs
    {
        public DeviceStatus Status { get; set; }
        public uint Ip { get; set; }

        public string ComPort { get; set; }

        public DeviceType Type { get; set; }

        public string getHumanReadableIp()
        {
            return $"IP: {IPAddress.Parse(Ip.ToString()).ToString()}";
        }

        public string getConnectionPort()
        {
            return $"PORT: {ComPort}";
        }

        public string getStatusDescription()
        {
            switch (Status) {
                case DeviceStatus.SEARCHING:
                    return "Searching...";
                case DeviceStatus.FOUND:
                    return "Reader found";
                case DeviceStatus.NOT_FOUND:
                    return "Reader does not found";
                case DeviceStatus.TRYING_CONNECT:
                    return "Trying connect to reader...";
                case DeviceStatus.CONNECTED:
                    return "Connected";
                case DeviceStatus.NOT_CONNECTED:
                    return "Does not connected to reader";
                default:
                    return "Something went wrong!";
            }
        }
    }
}
