using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order, string, Order>
    {
        public Order Create(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
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

        public Order Read(string id)
        {
            return db.Orders.Find(id);
        }

        public Order Update(Order obj)  
        {
            var ex = Read(obj.SenderName);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0) return obj;
            }
            return null;
        }
    }
}
