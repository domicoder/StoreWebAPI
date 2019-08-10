using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MODEL
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime DatePurchase { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

    }
}
