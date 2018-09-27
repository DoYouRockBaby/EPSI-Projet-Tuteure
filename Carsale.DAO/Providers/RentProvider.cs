using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Carsale.DAO.Models;

namespace Carsale.DAO.Providers
{
    public class RentProvider
    {
        private readonly CarsaleContext _db = new CarsaleContext();
        public void Add(Rent rent)
        {

            _db.Rents.Add(rent);
            _db.SaveChanges();

        }

        public IEnumerable<Rent> FindAll()
        {

            return _db.Rents.Include(r => r.Client).Include(r => r.Vehicle).ToList();

        }

        public Rent FindById(int? id)
        {
            return _db.Rents.Include(e => e.Client).Include(e => e.Vehicle).FirstOrDefault(e => e.Id == id);

        }

        public void Update(Rent rent)
        {
            _db.Entry(rent).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public void Delete(int id)
        {

            _db.Entry(FindById(id)).State = EntityState.Deleted;
            _db.SaveChanges();

        }
    }
}
