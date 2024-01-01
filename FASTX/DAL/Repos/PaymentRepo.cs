using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PaymentRepo : Repo, IRepo<Payment, int, Payment>
    {
        public Payment Create(Payment obj)
        {
            db.Payments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Payments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Read()
        {
            return db.Payments
                .Include(i => i.Package)
                .ToList();
        }

        public Payment Read(int id)
        {
            return db.Payments
                .Include(i => i.Package)
                .FirstOrDefault(i => i.Id == id);
        }

        public Payment Update(Payment obj)
        {
            var ex = Read(obj.Id);

            if (ex == null) return null;

            ex.Email = obj.Email;
            ex.PackageID = obj.PackageID;
            ex.TransactionType = obj.TransactionType;
            ex.PaymentMethod = obj.PaymentMethod;
            ex.TransactionID = obj.TransactionID;
            ex.Amount = obj.Amount;

            db.Payments.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
