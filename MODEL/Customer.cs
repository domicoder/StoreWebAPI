using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public DateTime BornDate { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
