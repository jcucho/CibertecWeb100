using Cibertec.Models;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.MVC.Models
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        //estructura de la plurzacion 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}
