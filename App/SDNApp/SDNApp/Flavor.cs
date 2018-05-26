using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Flavor
    {
        public string id;
        public string name;
        public int ram;
        public int vcpu;
        public int disk;

        public override string ToString()
        {
            return "Name: " + name;
        }
    }
}