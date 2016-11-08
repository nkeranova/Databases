using CarsSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Data
{
    public class CarSystemDbContext : DbContext
    {
        public CarSystemDbContext()
            : base("CarSystem")
        {

        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

    }
}
