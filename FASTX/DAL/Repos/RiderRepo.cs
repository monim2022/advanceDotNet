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
    public class RiderRepo : Repo, IRepo<Rider, int, Rider>
    {
        public Rider Create(Rider obj)
        {
            db.Riders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Riders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Rider> Read()
        {
            return db.Riders
                .Include(r => r.User)
                .Include(r => r.Branch)
                .ToList();
        }

        public Rider Read(int id)
        {
            return db.Riders
                .Include(r => r.User)
                .Include(r => r.Branch)
                .FirstOrDefault(i => i.RiderId == id);
        }

        public Rider Update(Rider obj)
        {
            var ex = Read(obj.RiderId);

            if (ex == null) return null;

            ex.BranchId = obj.BranchId;
            ex.UserId = obj.UserId;
            ex.VehicaleType = obj.VehicaleType;
            ex.Salary = obj.Salary;
            ex.Status = obj.Status;
            ex.Created_at = obj.Created_at;

            db.Riders.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
