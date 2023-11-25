using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_library_management_3.Models.Entity
{
    public class Books
    {
        
            public string isbn { get; set; }
            public string title { get; set; }
            public string writter { get; set; }
            public string genre { get; set; }
            public string publisher { get; set; }
            public int stocks { get; set; }
        
    }
}
