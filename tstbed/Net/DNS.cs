using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Net
{
    static class DNSTst
    {
        public static void Test()
        {
            Utils.WriteTopic("DNS");
            IPHostEntry host = Dns.GetHostEntry("www.nytimes.com");
            Utils.WriteDetailLine($"GetHostEntry: {host.HostName}");
        }
    }
}
