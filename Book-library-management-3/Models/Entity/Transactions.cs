﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_library_management_3.Models.Entity
{
    public class Transactions
    {
        public int transactions_id { get; set; }
        public string username { get; set; }
        public string isbn { get; set; }
        public string date { get; set; }
        public string status { get; set; }
    }
}
