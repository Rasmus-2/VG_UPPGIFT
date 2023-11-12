using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Bus : IVehicle
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Colour { get; set; }
        public int Seats { get; set; }
        public DateTime EnteredGarage { get; set; }

        public Bus(DMV dmv, string colour = "no colour", int seats = 0)
        {
            Name = "Bus";
            Plate = dmv.CreatePlate();
            Colour = colour;
            Seats = seats;
            EnteredGarage = DateTime.Now;
        }
    }
}