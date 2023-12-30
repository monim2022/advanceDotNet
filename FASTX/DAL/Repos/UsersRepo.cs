using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UsersRepo : Repo, IRepo<Users, string, Users>
    {
        public Users Create(Users obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
            return db.SaveChanges()>0;
        }

        public List<Users> Read()
        {
            return db.Users.ToList();
        }

        public Users Read(string id)
        {
            return db.Users.Find(id);
        }

        public Users Update(Users obj)
        {
            var ex = Read(obj.Username);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
            

        }
    }
}
