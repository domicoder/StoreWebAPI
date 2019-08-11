using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MODEL
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePurchase { get; set; } = DateTime.Now.ToUniversalTime();
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual ICollection<InvoiceProductDetail> Products { get; set; }
    }
}
