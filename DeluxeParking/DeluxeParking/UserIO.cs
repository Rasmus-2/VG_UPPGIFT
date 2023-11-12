using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class UserIO
    {
        public static void ShowMenu()
        {
            Console.WriteLine("[A]dmit next vehicle");
            Console.WriteLine("[C]heckout a vehicle");
            Console.WriteLine("[S]how list of vehicles");
            Console.WriteLine("[Q]uit the program");
        }

        public static string GetColour()
        {
            Console.Write("What colour is it? ");
            string colour = Console.ReadLine();
            return colour;
        }

        public static bool CheckElectric()
        {
            bool success = false;
            bool electric = false;

            Console.Write("Is it electric? ");

            while (!success)
            {
                string electricAnswer = Console.ReadLine();
                switch (electricAnswer.ToLower())
                {
                    case "yes":
                    case "y":
                    case "electric":
                        electric = true;
                        success = true;
                        break;
                    case "no":
                    case "n":
                        success = true;
                        break;
                    default:
                        Console.Write("Please write yes or no: ");
                        break;
                }
            }
            return electric;
        }

        public static int GetSeats()
        {
            bool success = false;
            int seats = 0;

            Console.Write("How many seats? ");

            while (!success)
            {
                string input = Console.ReadLine();
                success = int.TryParse(input, out seats);
                if (!success)
                {
                    Console.Write("Please enter an integer: ");
                }
            }
            return seats;
        }

        public static string GetMake()
        {
            Console.Write("What make is it? ");
            string make = Console.ReadLine();
            return make;
        }
    }
}