namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.Branches", "OpeningTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Branches", "ClosingTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Inventories", "PackagesInStock", c => c.Int());
            DropColumn("dbo.Orders", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventories", "PackagesInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Branches", "ClosingTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Branches", "OpeningTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
