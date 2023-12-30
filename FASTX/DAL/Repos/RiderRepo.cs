using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RiderRepo : Repo, IRepo<Rider, string, Rider>
    {
        public Rider Create(Rider obj)
        {
            db.Riders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Riders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Rider> Read()
        {
            return db.Riders.ToList();
        }

        public Rider Read(string id)
        {
            return db.Riders.Find(id);

        }

        public Rider Update(Rider obj)
        {
            var ex = Read(obj.Name);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
