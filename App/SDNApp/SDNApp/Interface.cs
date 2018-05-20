using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Interface
    {
        public string mac_address;
        public int version;
        public string ip_address;
        public string type;

        public override string ToString()
        {
            return "IPv4: " + ip_address + "     " + "type:" + type;
        }
    }
}