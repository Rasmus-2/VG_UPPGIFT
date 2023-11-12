using System.Drawing;

namespace DeluxeParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Garage garage = new Garage(15);
            DMV dmv = new DMV();
            Random rnd = new Random();

            while (!quit)
            {
                UserIO.ShowMenu();

                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                switch (key.KeyChar)
                {
                    case 'a':
                        garage.AdmitVehicle(dmv, rnd.Next(0, 3));
                        garage.ShowGarage();
                        break;
                    case 'c':
                        garage.ShowGarage();
                        garage.CheckoutVehicle();
                        break;
                    case 's':
                        garage.ShowGarage();
                        break;
                    case 'q':
                        quit = true;
                        break;
                }
            }
        }
    }
}