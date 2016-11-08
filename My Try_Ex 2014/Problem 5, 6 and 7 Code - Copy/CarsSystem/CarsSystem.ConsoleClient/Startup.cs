using CarSystem.Data;
using CarSystem.Data.Migrations;
using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarSystemDbContext, Configuration>());

            var db = new CarSystemDbContext();

            db.Cars.Count();
        }
    }
}
