using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class VehicleCreator
    {
        static Random rnd = new Random();

        internal static string PlateGenerator()
        {
            char[] plateLetters =
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U',
             'V', 'X', 'Y', 'Z'
            };
            string plate = "";
            for (int i = 0; i < 3; i++)
            {
                plate += plateLetters[rnd.Next(plateLetters.Length)];
            }
            for (int i = 0; i < 3; i++)
            {
                plate += rnd.Next(0, 10);
            }
            return plate;
        }
        internal static string VehiclePainter()
        {
            string[] colors = { "Röd", "Blå", "Grön", "Svart", "Vit", "Gul", "Silver", "Orange", "Lila", "Rosa" };
            return colors[rnd.Next(colors.Length)];
        }
        internal static string MotorCycleBrands()
        {
            string[] brands = { "Honda", "Yamaha", "Suzuki", "Kawasaki", "Harley-Davidson", "Ducati",
                "BMW", "KTM", "Triumph", "Royal Enfield" };
            return brands[rnd.Next(brands.Length)];
        }
        internal static bool RandomElectric()
        {
            return rnd.Next(2) == 1;
        }
        internal static int BusSize()
        {
            int[] busSeats = { 32, 38, 42, 45, 48, 50, 52, 55 };
            return busSeats[rnd.Next(busSeats.Length)];
        }
        internal static Motorcycle MotorcycleCreator()
        {
            string regPlate = PlateGenerator();
            string color = VehiclePainter();
            DateTime parkedTime = DateTime.Now;
            string brand = MotorCycleBrands();
           
            return new Motorcycle(regPlate, color, parkedTime, brand);
        }
        internal static Car CarCreator()
        {
            string regPlate = PlateGenerator();
            string color = VehiclePainter();
            DateTime parkedTime = DateTime.Now;
            bool electric = RandomElectric();

            return new Car(regPlate, color, parkedTime, electric);
        }
        internal static Bus BusCreator()
        {
            string regPlate = PlateGenerator();
            string color = VehiclePainter();
            DateTime parkedTime = DateTime.Now;
            int passengers = BusSize();

            return new Bus(regPlate, color, parkedTime, passengers);
        }
    }
}
