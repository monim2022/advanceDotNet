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
    public class PackageRepo : Repo, IRepo<Package, int, Package>
    {
        public Package Create(Package obj)
        {
            db.Packages.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Packages.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Package> Read()
        {
            return db.Packages
                .Include(i => i.Rider)
                .ToList(); 
        }

        public Package Read(int id)
        {
            return db.Packages
                .Include(i => i.Rider)
                .FirstOrDefault(i => i.PackageId == id);
        }

        public Package Update(Package obj)
        {
            var ex = Read(obj.PackageId);

            if (ex == null) return null;

            ex.SenderId = obj.SenderId;
            ex.RecipientId = obj.RecipientId;
            ex.Description = obj.Description;
            ex.Weight = obj.Weight;
            ex.DestinationAddress = obj.DestinationAddress;
            ex.ShippingMehtod = obj.ShippingMehtod;
            ex.Insurance = obj.Insurance;
            ex.EntitmatedDelivery = obj.EntitmatedDelivery;
            ex.DiliveryManId = obj.DiliveryManId;
            ex.PaymentStatus = obj.PaymentStatus;
            ex.PymentMethod = obj.PymentMethod;
            ex.Retuned = obj.Retuned;

            db.Packages.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
