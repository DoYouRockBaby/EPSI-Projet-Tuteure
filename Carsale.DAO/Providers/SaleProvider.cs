using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                return context.Sales.Include(e => e.Vehicle).Include(e => e.Client).ToList();
            }
        }

        public Sale FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Sales.Include(e => e.Vehicle).Include(e => e.Client).Where(e => e.Id == id).FirstOrDefault();
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
