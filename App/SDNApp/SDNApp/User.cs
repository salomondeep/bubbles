using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNApp
{
    public class Users
    {
        public List<User> data { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string nickname { get; set; }
    }
}
