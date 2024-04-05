using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.DNS
{
    public interface IDNSService
    {
        bool SendDNS(string host);
    }
    public class DNSService : IDNSService
    {
        public bool SendDNS(string host)
        {
            return true;
        }
    }
}
