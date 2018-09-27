using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
   public class TradeInProvider
    {

         public void Add(TradeIn tradeIn)
        {
            using (var context = new CarsaleContext())
            {
                context.TradeIns.Add(tradeIn);
                context.SaveChanges();
            }
        }

        public IEnumerable<TradeIn> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.TradeIns.Include(e => e.Vehicle).Include(e => e.Client).ToList();
            }
        }

        public TradeIn FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.TradeIns.Include(e => e.Vehicle).Include(e => e.Client).Where(e => e.Id == id).FirstOrDefault();
            }
        }

        public void Update(TradeIn tradeIn)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(tradeIn).State = EntityState.Modified;
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
