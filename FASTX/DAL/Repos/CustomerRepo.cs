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
    public class CustomerRepo : Repo, IRepo<Customer, int, Customer>, IAuth
    {
        public Customer Authenticate(string email, string password)
        {
            var customer = from e in db.Customers
                           where e.User.Email == email

                       && e.User.Password.Equals(password)
                           select e;
            if (customer != null) return customer.SingleOrDefault();
            return null;
        }

        public Customer Create(Customer obj)
        {
            db.Customers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Customers.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Customer> Read()
        {
            return db.Customers
                .Include(c => c.User)
                .ToList();
        }

        public Customer Read(int id)
        {
            return db.Customers
                .Include(i => i.User)
                .FirstOrDefault(i => i.CustomerId == id);
        }

        public Customer Update(Customer obj)
        {
            var ex = Read(obj.CustomerId);

            if (ex == null) return null;

            ex.UserId = obj.UserId;
            
            db.Customers.AddOrUpdate(ex);
            db.SaveChanges();

            return ex;
        }
    }
}
