using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
