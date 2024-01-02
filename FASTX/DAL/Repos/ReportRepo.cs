using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ReportRepo : Repo, IRepo<Report, int, Report>
    {
        public Report Create(Report obj)
        {
            db.Reports.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Reports.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Report> Read()
        {
            return db.Reports.ToList();
        }

        public Report Read(int id)
        {
            return db.Reports.Find(id);
        }

        public Report Update(Report obj)
        {
            throw new NotImplementedException();
        }
    }
}
