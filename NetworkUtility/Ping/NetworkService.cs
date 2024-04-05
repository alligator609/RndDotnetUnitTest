using System.Net.NetworkInformation;
using NetworkUtility.DNS;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNSService _iDNSService;
        public NetworkService(IDNSService iDNSService)
        {
            _iDNSService = iDNSService;
        }
        public string SendPing(string host)
        {
            var dnsSuccess = _iDNSService.SendDNS(host);
            if (dnsSuccess)
            {
                return "Pinging " + host;
            }
            else
            {
                return "Failed " + host;
            }
        }
        public int PingTime(int a, int b)
        {
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new  PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                 new  PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                  new  PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },

            };
            return pingOptions;
        }

    }
}
