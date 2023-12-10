using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_library_member.Models.entity
{
    public class transactions
    {
        public int transactions_id { get; set; }
        public string username { get; set; }
        public string isbn { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string title { get; set; }
    }
}
