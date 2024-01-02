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
    public class AdminRepo : Repo, IRepo<Admin, int, Admin>
    {
        public Admin Create(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Admins.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Admin> Read()
        {
            return db.Admins
                .Include(c => c.User)
                .ToList();
        }

        public Admin Read(int id)
        {
            return db.Admins
                .Include(i => i.User)
                .FirstOrDefault(i => i.AdminId == id);
        }

        public Admin Update(Admin obj)
        {
            var ex = Read(obj.AdminId);

            if (ex == null) return null;

            ex.UserId = obj.UserId;

            db.Admins.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
