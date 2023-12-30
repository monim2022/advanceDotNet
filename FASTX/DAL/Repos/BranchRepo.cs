using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BranchRepo : Repo, IRepo<Branch, string, Branch>
    {
        public Branch Create(Branch obj)
        {
            db.Branches.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Branches.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Branch> Read()
        {
            return db.Branches.ToList();
        }

        public Branch Read(string id)
        {
            return db.Branches.Find(id);
        }

        public Branch Update(Branch obj)
        {
            var ex = Read(obj.BranchName);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0) return obj;
            }
            return null;
        }
    }
}
