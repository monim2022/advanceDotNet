using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BranchContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<ReturnOder> ReturnOrders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ManagerSalary> ManagerSalarys { get; set;}
    }
}
