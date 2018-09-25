using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    public class PartProvider
    {
        public void Add(Part part)
        {
            using (var context = new CarsaleContext())
            {
                context.Parts.Add(part);
                context.SaveChanges();
            }
        }

        public IEnumerable<Part> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Parts.ToList();
            }
        }

        public Part FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Parts.Find(id);
            }
        }

        public void Update(Part part)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(part).State = EntityState.Modified;
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
