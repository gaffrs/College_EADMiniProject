namespace BikeHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        BikeID = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        RentalChargePerDay = c.Double(nullable: false),
                        BikeAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BikeID);
            
            CreateTable(
                "dbo.Hires",
                c => new
                    {
                        HireID = c.Int(nullable: false, identity: true),
                        BikeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HireID)
                .ForeignKey("dbo.Bikes", t => t.BikeID, cascadeDelete: true)
                .Index(t => t.BikeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hires", "BikeID", "dbo.Bikes");
            DropIndex("dbo.Hires", new[] { "BikeID" });
            DropTable("dbo.Hires");
            DropTable("dbo.Bikes");
        }
    }
}
