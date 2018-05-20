using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Project
    {
        public Boolean is_enabled;
        public string id;
        public string name;

        public override string ToString()
        {
            return "Name: " + name;
        }
    }
}