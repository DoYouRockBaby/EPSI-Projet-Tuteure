using Carsale.DAO.Models;
using System.Data.Entity;

namespace Carsale.DAO
{
    public class CarsaleContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « EnglishBattleModel » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « English_Battle.Dao.SqlServer.EnglishBattleModel » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « EnglishBattleModel » dans le fichier de configuration de l'application.
        public CarsaleContext()
            : base("name=CarsaleContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
