using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.SSLWirelessSMS
{
    public class SslWirelessSettings
    {
        public bool Enabled { get; set; } = false;
        public string ApiToken { get; set; } = string.Empty;
        public string Sid { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = "https://smsplus.sslwireless.com";
    }
}
