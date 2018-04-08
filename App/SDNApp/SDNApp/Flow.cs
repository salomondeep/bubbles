using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    class Flow
    {
        public Boolean Strict { get; set; }
        public int Order { get; set; }
        public int Id { get; set; }
        public int Hard_timeout { get; set; }
        public int Idle_timeout { get; set; }
        public String Flow_name { get; set; }
        public IPAddress Ipv4_destination { get; set; }
        public IPAddress Ipv4_source { get; set; }
        public int Priority { get; set; }
        public int Table_id { get; set; }

        //needed only for API
        public string openflow { get; set; }



        public override string ToString()
        {
            return "Name: " + Flow_name + "   " + "Id: " + Id;
        }
    }
}
