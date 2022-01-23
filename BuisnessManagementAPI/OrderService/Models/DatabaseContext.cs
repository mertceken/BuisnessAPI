using Microsoft.EntityFrameworkCore;
using OrderService.Models.Entities;

namespace OrderService.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=BuisnessDb;Integrated Security=True");

        }
    }
}
