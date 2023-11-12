using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Bike : IVehicle
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Colour { get; set; }
        public string Make { get; set; }
        public DateTime EnteredGarage { get; set; }

        public Bike(DMV dmv, string colour = "no colour", string make = "generic make")
        {
            Name = "Bike";
            Plate = dmv.CreatePlate();
            Colour = colour;
            Make = make;
            EnteredGarage = DateTime.Now;
        }
    }
}