using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
