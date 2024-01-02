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
    public class DeliveryStatusRepo : Repo, IRepo<DeliveryStatus, int, DeliveryStatus>
    {
        public DeliveryStatus Create(DeliveryStatus obj)
        {
            db.DeliveryStatuses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.DeliveryStatuses.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<DeliveryStatus> Read()
        {
            return db.DeliveryStatuses
                .Include(i => i.Package)
                .ToList();
        }

        public DeliveryStatus Read(int id)
        {
            return db.DeliveryStatuses
                .Include(i => i.Package)
                .FirstOrDefault(i => i.Id == id);
        }

        public DeliveryStatus Update(DeliveryStatus obj)
        {
            var ex = Read(obj.Id);

            if (ex == null) return null;

            ex.Status = obj.Status;
            ex.Timestamp = obj.Timestamp;
            ex.PackageId = obj.PackageId;
            ex.LastUpdatedBy = obj.LastUpdatedBy;

            db.DeliveryStatuses.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
