using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Server
    {
        public string id;
        public List<Interface> interfaces = new List<Interface>();
        public Flavor flavor = new Flavor();
        public string status;
        public string name;

        public override string ToString()
        {
            return "Name: " + name;
        }
    }
}