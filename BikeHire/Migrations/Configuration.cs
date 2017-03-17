namespace BikeHire.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BikeHire.Models.BikeHireContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BikeHire.Models.BikeHireContext context)
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

            context.Bikes.AddOrUpdate(p => p.BikeID,
                new Models.Bike { Make = "Trek", Model = "Madone", RentalChargePerDay = 25, BikeAvailable = false },
                new Models.Bike { Make = "Giant", Model = "Defy", RentalChargePerDay = 20, BikeAvailable = true },
                new Models.Bike { Make = "Boardman", Model = "Carbon", RentalChargePerDay = 15, BikeAvailable = true }
                );

            context.Hires.AddOrUpdate(r => r.HireID,
                new Models.Hire { BikeID = 1, FirstName = "Colm", Surname = "Gaffney", Address = "Dublin", PhoneNumber = "12345678", StartDate = new DateTime(2017, 03, 01), FinishDate = new DateTime(2017, 03, 03) },
                new Models.Hire { BikeID = 1, FirstName = "John", Surname = "Gaffney", Address = "Dublin", PhoneNumber = "12345678", StartDate = new DateTime(2017, 04, 01), FinishDate = new DateTime(2017, 04, 03) },
                new Models.Hire { BikeID = 3, FirstName = "Kevin", Surname = "Gaffney", Address = "Dublin", PhoneNumber = "12345678", StartDate = new DateTime(2017, 05, 01), FinishDate = new DateTime(2017, 05, 03) }
                );
        }
    }
}
