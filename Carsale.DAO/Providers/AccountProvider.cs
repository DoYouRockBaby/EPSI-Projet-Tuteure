using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Providers
{
    public class AccountProvider
    {
        public void Add(Account account)
        {
            using (var context = new CarsaleContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public IEnumerable<Account> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Accounts.ToList();
            }
        }

        public Account FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Accounts.Find(id);
            }
        }

        public Account FindByEmail(string email)
        {
            using (var context = new CarsaleContext())
            {
                return context.Accounts.SingleOrDefault(e => e.Email == email);
            }
        }

        public void Update(Account account)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(FindById(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
