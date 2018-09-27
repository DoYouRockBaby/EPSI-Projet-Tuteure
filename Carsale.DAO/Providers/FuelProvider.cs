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
                return context.Fuels.Include(m => m.FuelWholesaler).ToList();
            }
        }

        public Fuel FindByReference(string reference)
        {
            using (var context = new CarsaleContext())
            {
                return context.Fuels.Include(m => m.FuelWholesaler).Where(m => m.Reference == reference).FirstOrDefault();
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

        public void Delete(string reference)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(FindByReference(reference)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
