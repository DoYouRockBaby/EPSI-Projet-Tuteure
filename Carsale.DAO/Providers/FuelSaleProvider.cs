using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    public class FuelSaleProvider
    {
        public void Add(FuelSale fuelSales)
        {
            using (var context = new CarsaleContext())
            {
                context.FuelSales.Add(fuelSales);
                context.SaveChanges();
            }
        }

        public IEnumerable<FuelSale> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.FuelSales.ToList();
            }
        }

        public FuelSale FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.FuelSales.Find(id);
            }
        }

        public void Update(FuelSale fuelSales)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(fuelSales).State = EntityState.Modified;
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
