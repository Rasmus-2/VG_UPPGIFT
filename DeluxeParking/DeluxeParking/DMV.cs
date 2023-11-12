using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class DMV
    {
        private List<string> Plates { get; set; }

        public DMV()
        {
            Plates = new List<string>();
        }

        public string CreatePlate()
        {
            Random rnd = new Random();
            string newPlate;

            do
            {
                newPlate = "";
                for (int i = 0; i < 3; i++)
                {
                    char letter = (char)('A' + rnd.Next(0, 26));
                    newPlate += letter;
                }

                int number = rnd.Next(0, 1000);
                newPlate += number.ToString("D3");
            }
            while (Plates.Contains(newPlate));

            Plates.Add(newPlate);

            return newPlate;
        }
    }
}