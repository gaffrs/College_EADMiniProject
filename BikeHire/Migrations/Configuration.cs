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
            //AutomaticMigrationsEnabled = false; 
            AutomaticMigrationsEnabled = true; //CG
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

/*  //Seed Data
            context.Hires.AddOrUpdate(r => r.HireID,
                new Models.Hire { BikeID = 1, FirstName = "Colm", Surname = "Gaffney", Address = "Dublin 15", PhoneNumber = "0871234567", StartDate = new DateTime(2017, 03, 01), FinishDate = new DateTime(2017, 03, 03) },
                new Models.Hire { BikeID = 1, FirstName = "John", Surname = "Gaffney", Address = "Dublin 10", PhoneNumber = "0871235678", StartDate = new DateTime(2017, 04, 01), FinishDate = new DateTime(2017, 04, 10) },
                new Models.Hire { BikeID = 1, FirstName = "Aaron", Surname = "O'Leary", Address = "Dublin 1", PhoneNumber = "0871236666", StartDate = new DateTime(2017, 05, 01), FinishDate = new DateTime(2017, 05, 03) },
                new Models.Hire { BikeID = 2, FirstName = "John", Surname = "Swan", Address = "Cork", PhoneNumber = "0871234555", StartDate = new DateTime(2017, 05, 01), FinishDate = new DateTime(2017, 05, 10) },
                new Models.Hire { BikeID = 1, FirstName = "Mark", Surname = "Doran", Address = "Meath", PhoneNumber = "0123344444", StartDate = new DateTime(2017, 05, 07), FinishDate = new DateTime(2017, 05, 09) }
                );

            context.Bikes.AddOrUpdate(p => p.BikeID,
                new Models.Bike { Make = "Trek", Model = "Madone", RentalChargePerDay = 35, BikeAvailable = false },
                new Models.Bike { Make = "Giant", Model = "Defy", RentalChargePerDay = 20, BikeAvailable = true },
                new Models.Bike { Make = "Boardman", Model = "Carbon", RentalChargePerDay = 15, BikeAvailable = true },
                new Models.Bike { Make = "Raleigh", Model = "Grifter", RentalChargePerDay = 5, BikeAvailable = false },
                new Models.Bike { Make = "Giant", Model = "Defy Advanced 2", RentalChargePerDay = 30, BikeAvailable = true },
                new Models.Bike { Make = "Giant", Model = "Defy Advanced 1", RentalChargePerDay = 70, BikeAvailable = true },
                new Models.Bike { Make = "Cannondale", Model = "Slate", RentalChargePerDay = 20, BikeAvailable = true }
        );
*/




        }
    }
}
