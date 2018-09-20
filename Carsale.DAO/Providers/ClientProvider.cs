using Carsale.DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsale.DAO.Providers
{
    public class ClientProvider
    {
        public void Add(Client client)
        {
            using (var context = new CarsaleContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public IEnumerable<Client> FindAll()
        {
            using (var context = new CarsaleContext())
            {
                return context.Clients.ToList();
            }
        }

        public Client FindById(int id)
        {
            using (var context = new CarsaleContext())
            {
                return context.Clients.Find(id);
            }
        }

        public void Update(Client client)
        {
            using (var context = new CarsaleContext())
            {
                context.Entry(client).State = EntityState.Modified;
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
