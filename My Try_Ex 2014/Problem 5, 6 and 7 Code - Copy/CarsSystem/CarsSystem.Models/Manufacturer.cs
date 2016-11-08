using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Models
{
    public class Manufacturer
    {
        private ICollection<Car> cars;

        public Manufacturer()
        {
            this.cars = cars;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

    }
}
