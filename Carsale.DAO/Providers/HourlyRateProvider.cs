using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    public class HourlyRateProvider
    {
        public void Add(HourlyRate hourlyRate)
        {
            using (var context = new CarsaleContext())
            {
                context.HourlyRates.Add(hourlyRate);
                context.SaveChanges();
            }
        }

        public HourlyRate FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.HourlyRates.Find(id);
            }
        }

        public IEnumerable<HourlyRate> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.HourlyRates.ToList();
            }
        }

        public HourlyRate FindLastFromMaintenanceType(MaintenanceType maintenanceType)
        {
            using (var context = new CarsaleContext())
            {
                return context.HourlyRates.Where(h => h.MaintenanceType == maintenanceType).OrderByDescending(h => h.Price).First();
            }
        }

        public IEnumerable<HourlyRate> FindFromMaintenanceType(MaintenanceType maintenanceType)
        {
            using (var context = new CarsaleContext())
            {
                return context.HourlyRates.Where(h => h.MaintenanceType == maintenanceType).OrderByDescending(h => h.Price).ToList();
            }
        }

        public void Update(HourlyRate hourlyRate)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(hourlyRate).State = EntityState.Modified;
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
