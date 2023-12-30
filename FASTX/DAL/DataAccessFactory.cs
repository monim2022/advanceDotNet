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
        public static IRepo<Branch, string, Branch> BranchData()
        {
            return new BranchRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<ReturnOder, string, ReturnOder> ReturnOrderData()
        {
            return new ReturnOrderRepo();
        }
        public static IRepo<Rider, int, Rider> RiderData()
        {
            return new RiderRepo();
        }
        public static IRepo<Users, int, Users> UsersData()
        {
            return new UsersRepo();
        }
    }
}
