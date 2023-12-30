namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(nullable: false, maxLength: 20),
                        ManagerId = c.Int(nullable: false),
                        BranchName = c.String(),
                        Location = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        SenderName = c.String(nullable: false, maxLength: 20),
                        ReceiverName = c.String(nullable: false, maxLength: 20),
                        Status = c.String(nullable: false, maxLength: 20),
                        AssignedRiderId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.ReturnOders",
                c => new
                    {
                        ReturnOrderId = c.Int(nullable: false, identity: true),
                        OriginalOrderId = c.Int(nullable: false),
                        Reason = c.String(nullable: false, maxLength: 20),
                        Status = c.String(nullable: false, maxLength: 20),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReturnOrderId);
            
            CreateTable(
                "dbo.Riders",
                c => new
                    {
                        RiderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Salary = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RiderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Riders");
            DropTable("dbo.ReturnOders");
            DropTable("dbo.Orders");
            DropTable("dbo.Branches");
        }
    }
}
