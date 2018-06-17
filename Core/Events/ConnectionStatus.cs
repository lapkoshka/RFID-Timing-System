using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHF;
using System.Net;
using Core.Helpers;

namespace Core
{
    public class ConnectionStatusEventArgs : EventArgs
    {
        public DeviceStatus Status { get; set; }

        public uint Ip { get; set; }

        public string ComPort { get; set; }

        public DeviceType Type { get; set; }

        public string GetHumanReadableIp()
        {
            return $"IP: {IPAddress.Parse(Ip.ToString()).ToString()}";
        }

        public string GetConnectionPort()
        {
            return $"PORT: {ComPort}";
        }

        public string GetStatusDescription()
        {
            return Status.GetDescription();
        }
    }
}
