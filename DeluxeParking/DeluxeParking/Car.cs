using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Car : IVehicle
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Colour { get; set; }
        public bool Electric { get; set; }
        public DateTime EnteredGarage { get; set; }

        public Car(DMV dmv, string colour = "no colour", bool electric = false)
        {
            Name = "Car";
            Plate = dmv.CreatePlate();
            Colour = colour;
            Electric = electric;
            EnteredGarage = DateTime.Now;
        }
    }
}