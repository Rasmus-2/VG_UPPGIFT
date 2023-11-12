using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal interface IVehicle
    {
        string Name { get; set; }
        string Plate { get; set; }
        string Colour { get; set; }
        DateTime EnteredGarage { get; set; }
    }
}