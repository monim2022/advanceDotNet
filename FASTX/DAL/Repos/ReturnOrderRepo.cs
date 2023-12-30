using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReturnOrderRepo : Repo, IRepo<ReturnOder, string, ReturnOder>
    {
        public ReturnOder Create(ReturnOder obj)
        {
            db.ReturnOrders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.ReturnOrders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ReturnOder> Read()
        {
            return db.ReturnOrders.ToList();
        }

        public ReturnOder Read(string id)
        {
            return db.ReturnOrders.Find(id);
        }

        public ReturnOder Update(ReturnOder obj)
        {
            var existingReturnOrder = Read(obj.Status);

            if (existingReturnOrder != null)
            {
                db.Entry(existingReturnOrder).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0) return obj;
            }

            return null;
        }

    }
}
