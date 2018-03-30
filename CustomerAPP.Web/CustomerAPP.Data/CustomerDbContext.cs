using CustomerAPP.Model;
using System.Data.Entity;

namespace CustomerAPP.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext() :base ("Customer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomerDbContext, Migrations.Configuration>("Customer"));

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
