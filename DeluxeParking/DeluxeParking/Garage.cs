using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Garage
    {
        private int Spaces { get; set; }
        private IVehicle[,] Floor1 { get; set; }

        public Garage(int spaces = 15)
        {
            Spaces = spaces;
            Floor1 = new IVehicle[Spaces, 2];
        }

        public void AdmitVehicle(DMV dmv, int type)
        {
            string colour = "";
            bool success = false;

            switch (type)
            {
                case 0:
                    Console.WriteLine("A new car arrives");
                    colour = UserIO.GetColour();
                    bool electric = UserIO.CheckElectric();
                    Car car = new Car(dmv, colour, electric);
                    success = ParkVehicle(car);
                    break;
                case 1:
                    Console.WriteLine("A new bus arrives");
                    colour = UserIO.GetColour();
                    int seats = UserIO.GetSeats();
                    Bus bus = new Bus(dmv, colour, seats);
                    success = ParkVehicle(bus);
                    break;
                case 2:
                    Console.WriteLine("A new bike arrives");
                    colour = UserIO.GetColour();
                    string make = UserIO.GetMake();
                    Bike bike = new Bike(dmv, colour, make);
                    success = ParkVehicle(bike);
                    break;
            }
            if (!success)
            {
                Console.WriteLine("\nThere is currently no room for this vehicle in the garage");
            }
        }

        public void CheckoutVehicle()
        {
            Console.Write("Enter the plate of the vehicle you would like to check out ");
            string plate = Console.ReadLine().ToUpper();
            bool foundVehicle = false;
            DateTime vehicleEntered = DateTime.Now;

            for (int i = 0; i < Floor1.GetLength(0); i++)
            {
                for (int j = 0; j < Floor1.GetLength(1); j++)
                {
                    if (Floor1[i, j] != null && plate == Floor1[i, j].Plate)
                    {
                        if (Floor1[i, j] is Car car)
                        {
                            vehicleEntered = car.EnteredGarage;
                        }
                        else if (Floor1[i, j] is Bike bike)
                        {
                            vehicleEntered = bike.EnteredGarage;
                        }
                        else if (Floor1[i, j] is Bus bus)
                        {
                            vehicleEntered = bus.EnteredGarage;
                        }

                        foundVehicle = true;
                        Floor1[i, j] = null;
                    }
                }
            }
            if (foundVehicle)
            {
                TimeSpan parkedTime = DateTime.Now - vehicleEntered;
                double parkingFee = parkedTime.Minutes * 1.5;
                Console.WriteLine("\nCheckout successful, " + parkedTime.Minutes + " minutes parked, at a cost of " + parkingFee + " SEK\n");
            }
            else
            {
                Console.WriteLine("\nThere is no vehicle with that plate currently in the garage\n");
            }
        }

        public void ShowGarage()
        {
            string spaceInfo = "";
            string currentPlate = "";
            string spaceNumber = "";

            Console.WriteLine();
            for (int i = 0; i < Floor1.GetLength(0); i++)
            {
                for (int j = 0; j < Floor1.GetLength(1); j++)
                {
                    if (Floor1[i, j] != null)
                    {
                        if (currentPlate != Floor1[i, j].Plate)
                        {
                            currentPlate = Floor1[i, j].Plate;
                            spaceNumber += "Space " + (i + 1).ToString();
                            if ((i + 1) < Floor1.GetLength(0) && Floor1[(i + 1), j] != null && currentPlate == Floor1[(i + 1), j].Plate)
                            {
                                spaceNumber += "-" + (i + 2).ToString();
                            }

                            spaceInfo += String.Format("{0,-12}{1,-8}{2,-10}{3,-10}", spaceNumber, Floor1[i, j].Name, Floor1[i, j].Plate, Floor1[i, j].Colour);
                            spaceNumber = "";

                            if (Floor1[i, j] is Car car)
                            {
                                spaceInfo += car.Electric ? "Electric\n" : "Gas\n";
                            }
                            else if (Floor1[i, j] is Bike bike)
                            {
                                spaceInfo += bike.Make + "\n";
                            }
                            else if (Floor1[i, j] is Bus bus)
                            {
                                spaceInfo += bus.Seats + "\n";
                            }
                        }
                    }
                }
                if (spaceInfo != "")
                {
                    Console.Write(spaceInfo);
                    spaceInfo = "";
                }
            }
            Console.WriteLine();
        }

        private bool ParkVehicle(Bike bike)
        {
            for (int i = 0; i < Floor1.GetLength(0); i++)
            {
                for (int j = 0; j < Floor1.GetLength(1); j++)
                {
                    if (Floor1[i, j] is null)
                    {
                        Floor1[i, j] = bike;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ParkVehicle(Car car)
        {
            int availableSize = 0;

            for (int i = 0; i < Floor1.GetLength(0); i++)
            {
                for (int j = 0; j < Floor1.GetLength(1); j++)
                {
                    if (Floor1[i, j] is null)
                    {
                        availableSize++;
                    }
                    if (availableSize >= 2)
                    {
                        Floor1[i, (j - 1)] = car;
                        Floor1[i, j] = car;
                        return true;
                    }
                }
                availableSize = 0;
            }
            return false;
        }

        private bool ParkVehicle(Bus bus)
        {
            int currentSpace = 0;
            int lastSpace = 0;

            for (int i = 0; i < Floor1.GetLength(0); i++)
            {
                for (int j = 0; j < Floor1.GetLength(1); j++)
                {
                    if (Floor1[i, j] is null)
                    {
                        currentSpace++;
                    }
                    else
                    {
                        currentSpace = 0;
                        lastSpace = 0;
                        break;
                    }

                    if (currentSpace + lastSpace >= 4)
                    {
                        Floor1[(i - 1), (j - 1)] = bus;
                        Floor1[(i - 1), j] = bus;
                        Floor1[i, (j - 1)] = bus;
                        Floor1[i, j] = bus;
                        return true;
                    }
                }
                if (currentSpace >= 2)
                {
                    currentSpace = 0;
                    lastSpace = 2;
                }
            }
            return false;
        }
    }
}