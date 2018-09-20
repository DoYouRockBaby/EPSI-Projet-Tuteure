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
<<<<<<< HEAD
        public DbSet<Sale> Sales { get; set; } // kelase sal publicesh ro yadam rafte bod
        //beben agr neaz basheh badan ham tagher bede rahat meshe ye partial ezafeh kard 

=======
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
>>>>>>> 805c7946d168554295a2f383d116760f2178db5f
    }
}
