namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.BranchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.BranchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           for (int i = 0; i<=10; i++) {
            context.Users.AddOrUpdate(new Models.Users
            {
                Name = Guid.NewGuid().ToString().Substring(0,15),
                Username = "User-"+i,
                Password = Guid.NewGuid().ToString().Substring(0,10),
                Type = "General",

            });
            }
           for (int i = 0;i<=10; i++)
            {
                context.Branches.AddOrUpdate(new Models.Branch
                {
                    BranchId = i,
                    BranchName= Guid.NewGuid().ToString().Substring(0,10),
                    ManagerId = i,
                    Location=Guid.NewGuid().ToString().Substring(0,10),
                    ManagerName=Guid.NewGuid().ToString().Substring(0,10),

                });
            }
            for (int i = 0; i <= 10; i++)
            {
                context.Riders.AddOrUpdate(new Models.Rider
                {
                    RiderId = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Salary = i * 1000, 
                    BranchId = i
                });

            }
            for (int i = 0; i <= 10; i++)
            {
                context.Orders.AddOrUpdate(new Models.Order
                {
                    OrderId = i,
                    SenderName = Guid.NewGuid().ToString().Substring(0, 10),
                    ReceiverName = Guid.NewGuid().ToString().Substring(0, 10),
                    Status = Guid.NewGuid().ToString().Substring(0, 10),
                    AssignedRiderId = i, 
                    BranchId = i
                });

            }
            for (int i = 0; i <= 10; i++)
            {
                context.ReturnOrders.AddOrUpdate(new Models.ReturnOder
                {
                    ReturnOrderId = i,
                    OriginalOrderId = i,
                    Reason = Guid.NewGuid().ToString().Substring(0, 10),
                    Status = Guid.NewGuid().ToString().Substring(0, 10),
                    BranchId = i
                });

            }


        }
    }
}
