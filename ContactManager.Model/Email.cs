﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model
{
    public class Email
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
