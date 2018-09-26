using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    public class FuelProvider
    {
        public void Add(Fuel fuel)
        {
            using (var context = new CarsaleContext())
            {
                context.Fuels.Add(fuel);
                context.SaveChanges();
            }
        }

        public IEnumerable<Fuel> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Fuels.ToList();
            }
        }

        public Fuel FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Fuels.Find(id);
            }
        }

        public void Update(Fuel fuel)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(fuel).State = EntityState.Modified;
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
