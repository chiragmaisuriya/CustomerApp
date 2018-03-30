namespace CustomerAPP.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CustomerAPP.Data.CustomerDbContext";
        }

        protected override void Seed(CustomerAPP.Data.CustomerDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var customers = new List<Customer>()
            //{
            //    new Customer() { Address = "Sample Address",BirthDay = DateTime.Today.AddYears(-30),FirstName = "Alex", LastName ="Walton" },
            //    new Customer() { Address = "New Address",BirthDay = DateTime.Today.AddYears(-40),FirstName = "Susan", LastName ="Miller" }
            //};

            //customers.ForEach(customer => context.Customers.AddOrUpdate(customer));
            //context.SaveChanges();
        }
    }
}
