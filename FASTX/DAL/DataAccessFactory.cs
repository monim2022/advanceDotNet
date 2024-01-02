using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Branch, int, Branch> BranchData()
        {
            return new BranchRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<ReturnOder, int, ReturnOder> ReturnOrderData()
        {
            return new ReturnOrderRepo();
        }
        public static IRepo<User, int, User> UsersData()
        {
            return new UsersRepo();
        }
        public static IRepo<Manager, int, Manager> ManagerData()
        {
            return new ManagerRepo();
        }
        public static IRepo<Inventory, int, Inventory> InventoryData()
        {
            return new InventoryRepo();
        }
        public static IRepo<Customer, int, Customer> CoustomerData()
        {
            return new CustomerRepo();
        }
        public static IAuth AuthData()
        {
            return new CustomerRepo();
        }
        public static IRepo<Rider, int, Rider> RiderData()
        {
            return new RiderRepo();
        }
        public static IRepo<Package, int, Package> PackageData()
        {
            return new PackageRepo();
        }
        public static IRepo<DeliveryStatus, int, DeliveryStatus> DeliveryStatusData()
        {
            return new DeliveryStatusRepo();
        }
        public static IRepo<Payment, int, Payment> PaymentData()
        {
            return new PaymentRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<Admin, int, Admin> AdminData()
        {
            return new AdminRepo();
        }
        public static IRepo<Report, int, Report> ReportData()
        {
            return new ReportRepo();
        }
        public static IRepo<ManagerSalary, int, ManagerSalary> ManagerSalaryData()
        {
            return new ManagerSalaryRepo();
        }
    }
}