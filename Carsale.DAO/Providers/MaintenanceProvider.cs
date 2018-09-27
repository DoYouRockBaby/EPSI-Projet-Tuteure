using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Providers
{
    public class MaintenanceProvider
    {
        public void Add(Maintenance maintenance)
        {
            using (var context = new CarsaleContext())
            {

                if(maintenance.Parts != null && maintenance.Parts.Count > 0)
                {
                    context.Maintenances.Attach(maintenance);
                    foreach (var part in maintenance.Parts)
                    {
                        context.Parts.Attach(part);
                    }

                    context.Entry(maintenance).State = EntityState.Added;

                }
                else
                {
                    context.Maintenances.Add(maintenance);
                }

                context.SaveChanges();
            }
        }

        public IEnumerable<Maintenance> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Maintenances.Include(m => m.Parts).Include(m => m.Vehicle).Include(m => m.Vehicle.Brand).Include(m => m.HourlyRate).ToList();
            }
        }

        public IEnumerable<Maintenance> FindAllUnbilled()
        {
            using (var context = new CarsaleContext())
            {
                return context.Maintenances.Include(m => m.Parts).Include(m => m.Vehicle).Include(m => m.Vehicle.Brand).Include(m => m.HourlyRate).Where(e=> context.MaintenanceBills.Where(b => b.MaintenanceId == e.Id).Count() == 0).ToList();
            }
        }

        public Maintenance FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Maintenances.Include(m => m.Parts).Include(m => m.Vehicle).Include(m => m.Vehicle.Brand).Include(m => m.HourlyRate).Where(m => m.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<Maintenance> FindByVehicle(string matriculation)
        {
            using (var context = new CarsaleContext())
            {
                return context.Maintenances.Include(m => m.Parts).Include(m => m.Vehicle).Include(m => m.Vehicle.Brand).Include(m => m.HourlyRate).Where(m => m.VehicleMatriculation == matriculation).ToList();
            }
        }

        public void Update(Maintenance maintenance)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(maintenance).State = EntityState.Modified;
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
