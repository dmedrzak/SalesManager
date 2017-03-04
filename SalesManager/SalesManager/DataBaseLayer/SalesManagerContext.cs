using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SalesManager.DataBaseLayer.Models;

namespace SalesManager.DataBaseLayer
{
    class SalesManagerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure CustomerId as PK for Address
            modelBuilder.Entity<Customer>()
                .HasKey(e => e.Id);

            // Configure CustomerId as FK for StudentAddress
            modelBuilder.Entity<Customer>()
                        .HasRequired(s => s.Address)
                        .WithRequiredPrincipal(ad => ad.Customer);

        }
    }
}
