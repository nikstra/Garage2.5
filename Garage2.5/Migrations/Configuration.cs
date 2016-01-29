namespace Garage2.Migrations
{
    using Garage2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.VehiclesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Garage2.Models.VehiclesDb context)
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

            context.Members.AddOrUpdate(
                n => n.Name,
                new Member { Name = "Mai", email = "Mai@example.com", mobile = "070-111111" },
                new Member { Name = "Mouhannad", email = "Mouhannad@example.com", mobile = "070-222222" },
                new Member { Name = "Niklas", email = "Niklas@example.com", mobile = "070-333333" }
                );

            context.VehicleTypes.AddOrUpdate(
                t => t.Type,
                new VehicleType { Type = "Bil" },
                new VehicleType { Type = "Buss" },
                new VehicleType { Type = "Båt" },
                new VehicleType { Type = "Flygplan" },
                new VehicleType { Type = "Motorcykel" }
                );


            context.vehicles.AddOrUpdate(
                r => r.RegNumber,
                new vehicle { RegNumber = "ABC 123", Colour = "röd", VehicleTypeId = 1, MemberId = 1, Model = "Volvo", Wheels = 4, ParkedTime = new DateTime(2016, 1, 28, 13, 24, 0), VehicleType = new VehicleType { Type = "Bil" } },
                new vehicle { RegNumber = "BCD 456", Colour = "blå", VehicleTypeId = 1, MemberId = 2, Model = "Saab", Wheels = 4, ParkedTime = new DateTime(2016, 1, 24, 10, 12, 0), VehicleType = new VehicleType { Type = "Bil" } },
                new vehicle { RegNumber = "CDE 789", Colour = "gul", VehicleTypeId = 1, MemberId = 3, Model = "Opel", Wheels = 4, ParkedTime = new DateTime(2016, 1, 29, 8, 56, 0), VehicleType = new VehicleType { Type = "Bil" } }
                );
        }
    }
}
