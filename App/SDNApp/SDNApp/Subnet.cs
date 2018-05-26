using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Subnet
    {
        public string network_id;
        public string id;
        public int ip_version;
        public IPAddress ip_start;
        public IPAddress ip_end;
        public IPAddress ip_gateway;
        public string cidr;
        public string name;

        public override string ToString()
        {
            return "Name: " + name;
        }
    }
}