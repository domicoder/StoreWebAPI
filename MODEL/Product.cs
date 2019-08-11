using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<InvoiceProductDetail> Invoices { get; set; }
    }
}
