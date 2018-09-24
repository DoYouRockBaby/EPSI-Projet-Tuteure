using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Providers
{
    public class SaleProvider
    {
        public void Add(Sale Sale)
        {
            using (var context = new CarsaleContext())
            {
                context.Sales.Add(Sale);
                context.SaveChanges();
            }
        }

        public IEnumerable<Sale> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Sales.ToList();
            }
        }

        public Sale FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Sales.Find(id);
            }
        }

        public void Update(Sale Sale)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(Sale).State = EntityState.Modified;
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
