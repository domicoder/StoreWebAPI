using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MODEL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(80)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
        [MaxLength(10)]
        [Required]
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
