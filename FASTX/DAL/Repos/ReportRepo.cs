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
            if (ex != null)
            {
                db.Reports.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Report> Read()
        {
            return db.Reports
                .Include(c => c.User)
                .ToList();
        }

        public Report Read(int id)
        {
            return db.Reports
                .Include(i => i.User)
                .FirstOrDefault(i => i.ReportId == id);
        }

        public Report Update(Report obj)
        {
            var ex = Read(obj.ReportId);

            if (ex == null) return null;

            ex.Title = obj.Title;
            ex.ReportDate = obj.ReportDate;
            ex.Description = obj.Description;
            ex.UserId = obj.UserId;

            db.Reports.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
