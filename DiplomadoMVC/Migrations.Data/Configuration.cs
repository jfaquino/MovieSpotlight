namespace DiplomadoMVC.Migrations.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //Enable-Migrations -ContextTypeName DiplomadoMVC.Data.DiplomadoDbContext -MigrationsDirectory Migrations.Data
    //Update-Database -ConfigurationTypeName DiplomadoMVC.Migrations.Data.Configuration
    internal sealed class Configuration : DbMigrationsConfiguration<DiplomadoMVC.Data.DiplomadoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations.Data";
        }

        protected override void Seed(DiplomadoMVC.Data.DiplomadoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
