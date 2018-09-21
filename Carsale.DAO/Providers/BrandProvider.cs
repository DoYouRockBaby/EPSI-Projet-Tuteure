using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Providers
{
   public class BrandProvider
    {
        public void Add(Brand brand)
        {
            using (var carsaleContext = new CarsaleContext())
            {
                carsaleContext.Brands.Add(brand);
                carsaleContext.SaveChanges();
            }
        }
        public IEnumerable<Brand> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Brands.ToList();
            }
        }
        public Brand FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Brands.Where(e => e.Id == id).FirstOrDefault();
            }
        }
        public void Update(Brand brand)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(brand).State = EntityState.Modified;
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
