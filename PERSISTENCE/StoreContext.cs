using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PERSISTENCE
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
      //  {
      //      modelBuilder.Entity<InvoiceProductDetail>().HasKey(x => new { x.InvoiceId, x.ProductId });
       // }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InvoiceProductDetail> InvoiceProductDetails { get; set; }
    }
}
