using Carsale.DAO.Models;
using System.Data.Entity;

namespace Carsale.DAO
{
    public class CarsaleContext : DbContext
    {
        public CarsaleContext()
            : base("name=CarsaleContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<HourlyRate> HourlyRates { get; set; }
    }
}
