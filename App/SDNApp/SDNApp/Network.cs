using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Network
    {
        public string id;
        public string name;
        public List<Subnet> interfaces = new List<Subnet>();

        public override string ToString()
        {
            return "Name: " + name;
        }
    }
}