using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order, int, Order>
    {
        public Order Create(Order OrderId)
        {
            db.Orders.Add(OrderId);
            if (db.SaveChanges() > 0) return OrderId;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Orders.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

       
        public List<Order> Read()
        {
            return db.Orders.ToList();  
        }

        public Order Read(int id)
        {
            return db.Orders.Find(id);
        }

       
        public Order Update(Order OrderId)  
        {
            var ex = Read(OrderId.OrderId);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(OrderId);
                if (db.SaveChanges() > 0) return OrderId;
            }
            return null;
        }

        
    }
}
