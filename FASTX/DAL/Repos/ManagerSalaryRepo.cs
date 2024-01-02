using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ManagerSalaryRepo : Repo, IRepo<ManagerSalary, int, ManagerSalary>
    {
        public ManagerSalary Create(ManagerSalary obj)
        {
            db.ManagerSalarys.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.ManagerSalarys.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<ManagerSalary> Read()
        {
            return db.ManagerSalarys.ToList();

        }

        public ManagerSalary Read(int id)
        {
            return db.ManagerSalarys.Find(id);
        }

        public ManagerSalary Update(ManagerSalary obj)
        {
            var ex = Read(obj.ManagerSalId);

            if (ex == null)
            {
                return null;
            }

            ex.ManagerId = obj.ManagerId;
            ex.SalAmmount = obj.SalAmmount;
            db.ManagerSalarys.AddOrUpdate(ex); 
            db.SaveChanges();

            return ex;
        }

    }
}
