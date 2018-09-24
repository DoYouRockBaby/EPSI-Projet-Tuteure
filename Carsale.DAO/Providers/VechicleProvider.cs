using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    public class VechicleProvider
    {
        public void Add(Vehicle vehicle)
        {
            using (var carsaleContext = new CarsaleContext())
            {
                carsaleContext.Vehicles.Add(vehicle);
                carsaleContext.SaveChanges();
            }
        }
        public IEnumerable<Vehicle> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return (from vehicle in context.Vehicles where !(from sale in context.Sales select sale.VehicleMatriculation).Contains(vehicle.Matriculation) select vehicle).Include((v) => v.Brand).ToList();
            }
        }
        public Vehicle FindByMatriculation(string matriculation)
        {
            using (var context = new CarsaleContext())
            {
                return context.Vehicles.Include((v) => v.Brand).Where(e => e.Matriculation == matriculation).FirstOrDefault();
            }
        }
        public void Update(Vehicle vehicle)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(vehicle).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(String matriculation)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(FindByMatriculation(matriculation)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
