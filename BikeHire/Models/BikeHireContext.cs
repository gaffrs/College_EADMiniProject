using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BikeHire.Models
{
    public class BikeHireContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BikeHireContext() : base("name=BikeHireContext")
        {
        }

        public System.Data.Entity.DbSet<BikeHire.Models.Bike> Bikes { get; set; }

        public System.Data.Entity.DbSet<BikeHire.Models.Hire> Hires { get; set; }


        //Uncomment below and recreate tables....to Specify singular table names
        /*
         * protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */

    }
}
