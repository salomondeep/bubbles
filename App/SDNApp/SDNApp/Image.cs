using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    internal class Image
    {
        public string id;
        public string name;
        public Boolean status;
        public int size;

        public override string ToString()
        {
            return "Name: " + name;
        }
    }
}