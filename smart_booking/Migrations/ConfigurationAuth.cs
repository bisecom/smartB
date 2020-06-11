namespace smart_booking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationAuth : DbMigrationsConfiguration<smart_booking.Models.ApplicationDbContext>
    {
        public ConfigurationAuth()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations";
            ContextKey = "smart_booking.Models.ApplicationDbContext";
        }

        protected override void Seed(smart_booking.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
