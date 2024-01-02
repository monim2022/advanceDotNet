using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
   
        public class ManagerSalaryRepo : Repo, IRepo<ManagerSalary, int, ManagerSalary>
        {
            public ManagerSalary Create(ManagerSalary obj)
            {
                db.ManagerSalaries.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
                
            }

            public bool Delete(int id)
            {
                throw new NotImplementedException();
            }

            public List<ManagerSalary> Read()
            {
                throw new NotImplementedException();
            }

            public ManagerSalary Read(int id)
            {
                throw new NotImplementedException();
            }

            public ManagerSalary Update(ManagerSalary obj)
            {
                throw new NotImplementedException();
            }
        }
    
}
