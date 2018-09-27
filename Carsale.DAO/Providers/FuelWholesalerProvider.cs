using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    public class FuelWholesalerProvider
    {
        public void Add(FuelWholesaler fuelWholesaler)
        {
            using (var context = new CarsaleContext())
            {
                context.FuelWholesalers.Add(fuelWholesaler);
                context.SaveChanges();
            }
        }

        public IEnumerable<FuelWholesaler> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.FuelWholesalers.ToList();
            }
        }

        public FuelWholesaler FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.FuelWholesalers.Find(id);
            }
        }

        public void Update(FuelWholesaler fuelWholesaler)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(fuelWholesaler).State = EntityState.Modified;
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
