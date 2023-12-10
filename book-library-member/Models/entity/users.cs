using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_library_member.Models.entity
{
    public class users
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string date_register { get; set; }
    }
}
