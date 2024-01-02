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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Models.BranchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
             for (int i = 1; i <= 10; i++)
            {
                context.Users.AddOrUpdate(new Models.User
                {
                    FirstName = Guid.NewGuid().ToString().Substring(0,10),
                    LastName = Guid.NewGuid().ToString().Substring(0, 10),
                    Username = "User-"+i,
                    Email = Guid.NewGuid().ToString().Substring(0, 15),
                    Password = Guid.NewGuid().ToString().Substring(0, 15),
                    ContactNumber = Guid.NewGuid().ToString().Substring(0, 15),
                    Address = Guid.NewGuid().ToString().Substring(0, 15),
                    Role = "manager",





                });
            }
        }
    }
}
