using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_library_management_3.Models.Entity
{
    public class Users
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string date_register { get; set; }
    }
}
