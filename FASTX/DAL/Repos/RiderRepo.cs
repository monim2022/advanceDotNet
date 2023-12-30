using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RiderRepo : Repo, IRepo<Rider, int, Rider>
    {
        public Rider Create(Rider obj)
        {
            db.Riders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int RiderId)
        {
            var ex = Read(RiderId);
            db.Riders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Rider> Read()
        {
            return db.Riders.ToList();
        }

        public Rider Read(int id)
        {
            return db.Riders.Find(id);

        }

        public Rider Update(Rider id)
        {
            var ex = Read(id.RiderId);
            db.Entry(ex).CurrentValues.SetValues(id);
            if (db.SaveChanges() > 0) return id;
            return null;
        }
    }
}
