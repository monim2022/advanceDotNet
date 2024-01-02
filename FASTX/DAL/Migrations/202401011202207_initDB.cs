namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        Location = c.String(),
                        ContactNumber = c.String(),
                        OpeningTime = c.DateTime(nullable: false),
                        ClosingTime = c.DateTime(nullable: false),
                        Is24HourBranch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        Address = c.String(),
                        Capacity = c.Int(nullable: false),
                        PackagesInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Level = c.String(),
                        BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryAddress = c.String(),
                        OrderStatus = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.ReturnOders",
                c => new
                    {
                        ReturnId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ReturnReason = c.String(),
                        ReturnDate = c.DateTime(nullable: false),
                        ReturnStatus = c.String(),
                        RefundAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ReturnId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReturnOders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Managers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Managers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Inventories", "BranchId", "dbo.Branches");
            DropIndex("dbo.ReturnOders", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "InventoryId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Managers", new[] { "BranchId" });
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.Inventories", new[] { "BranchId" });
            DropTable("dbo.ReturnOders");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Managers");
            DropTable("dbo.Inventories");
            DropTable("dbo.Branches");
        }
    }
}
