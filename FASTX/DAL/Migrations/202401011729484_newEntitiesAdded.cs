namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newEntitiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeliveryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        PackageId = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Weight = c.Double(nullable: false),
                        DestinationAddress = c.String(nullable: false),
                        ShippingMehtod = c.Int(nullable: false),
                        Insurance = c.Boolean(),
                        EntitmatedDelivery = c.DateTime(nullable: false),
                        DiliveryManId = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        PymentMethod = c.Int(nullable: false),
                        Retuned = c.Boolean(),
                    })
                .PrimaryKey(t => t.PackageId)
                .ForeignKey("dbo.Riders", t => t.DiliveryManId, cascadeDelete: true)
                .Index(t => t.DiliveryManId);
            
            CreateTable(
                "dbo.Riders",
                c => new
                    {
                        RiderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        VehicaleType = c.String(),
                        Salary = c.Double(nullable: false),
                        Status = c.String(),
                        Created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RiderId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        PackageID = c.Int(nullable: false),
                        TransactionType = c.String(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        TransactionID = c.String(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageID, cascadeDelete: true)
                .Index(t => t.PackageID);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        CustomerId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "NID", c => c.String());
            AddColumn("dbo.Users", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Payments", "PackageID", "dbo.Packages");
            DropForeignKey("dbo.DeliveryStatus", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Packages", "DiliveryManId", "dbo.Riders");
            DropForeignKey("dbo.Riders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Riders", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "CustomerId" });
            DropIndex("dbo.Payments", new[] { "PackageID" });
            DropIndex("dbo.Riders", new[] { "BranchId" });
            DropIndex("dbo.Riders", new[] { "UserId" });
            DropIndex("dbo.Packages", new[] { "DiliveryManId" });
            DropIndex("dbo.DeliveryStatus", new[] { "PackageId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropColumn("dbo.Users", "DOB");
            DropColumn("dbo.Users", "NID");
            DropColumn("dbo.Users", "Gender");
            DropTable("dbo.Tokens");
            DropTable("dbo.Payments");
            DropTable("dbo.Riders");
            DropTable("dbo.Packages");
            DropTable("dbo.DeliveryStatus");
            DropTable("dbo.Customers");
        }
    }
}
