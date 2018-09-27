using Carsale.DAO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Carsale.DAO.Providers
{
    class MaintenanceBillProvider
    {
        public void Add(MaintenanceBill bill)
        {
            using (var context = new CarsaleContext())
            {
                context.MaintenanceBills.Add(bill);
                context.SaveChanges();
            }
        }

        public IEnumerable<MaintenanceBill> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.MaintenanceBills.ToList();
            }
        }

        public IEnumerable<MaintenanceBill> FindAllPaid()
        {
            using (var context = new CarsaleContext())
            {
                return context.MaintenanceBills.Where(e => e.Status == MaintenanceBillStatus.Paid).ToList();
            }
        }

        public IEnumerable<MaintenanceBill> FindAllUnpaid()
        {
            using (var context = new CarsaleContext())
            {
                return context.MaintenanceBills.Where(e => e.Status == MaintenanceBillStatus.Unpaid).ToList();
            }
        }

        public MaintenanceBill FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.MaintenanceBills.Find(id);
            }
        }

        public void Update(MaintenanceBill bill)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(bill).State = EntityState.Modified;
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
