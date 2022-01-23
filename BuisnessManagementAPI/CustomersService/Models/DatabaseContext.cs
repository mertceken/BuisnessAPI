using Microsoft.EntityFrameworkCore;

namespace CustomersService.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=BuisnessDb;Integrated Security=True");

        }
    }
}
