namespace Carsale.DAO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Carsale.DAO.CarsaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Carsale.DAO.CarsaleContext context)
        {
            if(context.Accounts.Count() == 0)
            {
                context.Accounts.Add(new Models.Account()
                {
                    FirstName = "Hugo",
                    LastName = "Boss",
                    Email = "admin@carsale.com",
                    Type = Models.AccountType.Director,
                    Password = "admin"
                });

                context.SaveChanges();
            }
        }
    }
}
