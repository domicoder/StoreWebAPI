using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MODEL
{
    public class InvoiceProductDetail
    {
        public int InvoiceProductDetailId { get; set; }
        [ForeignKey("Invoice")]
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

    }
}
