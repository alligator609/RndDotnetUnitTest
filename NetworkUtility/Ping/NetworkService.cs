using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing(string host)
        {
            return "Pinging " + host;
        }
        public int PingTime(int a, int b )
        {
            return a + b;
        }
    }
}
