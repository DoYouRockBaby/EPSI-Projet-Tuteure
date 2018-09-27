using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carsale.DAO.Models;

namespace Carsale.DAO.Providers
{
  public class NotificationProvider
    {
        private readonly CarsaleContext _db = new CarsaleContext();
        public void Add(Notification notification)
        {

            _db.Notifications.Add(notification);
            _db.SaveChanges();

        }

        public IEnumerable<Notification> FindAll(string date)
        {

            return _db.Notifications.Where(c=> c.ShowDate == date).ToList();

        }
    }
}
