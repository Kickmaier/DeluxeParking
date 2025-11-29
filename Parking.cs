using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class ParkingSpot
    {
        public const float SpotCapcity = 1.0f;
        public float SpotUsed { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public ParkingSpot(float spotUsed)
        {
            SpotUsed = spotUsed;
            Vehicles = new List<Vehicle>();
        }

        public void Occupied()
        {
            if (SpotUsed == 0f)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ledig");
            }
            else if (SpotUsed == 0.5f)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ledig");
            }
            else if (SpotUsed == 1.0f)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Upptagen ");
                Console.ResetColor();
                foreach (Vehicle v in Vehicles)
                {
                    if (v is Motorcycle m)
                    {
                        Console.WriteLine($"{m.LicensePlate} {m.Brand} {m.VehicleColor}");
                    }
                    else if (v is Car c)
                    {
                        string engineType = c.Electric ? "Elektisk" : "Förbränning";
                        Console.WriteLine($"{c.LicensePlate} {engineType} {c.VehicleColor}");
                    }
                    else if (v is Bus b)
                    {
                        Console.WriteLine($"{b.LicensePlate} {b.Passengers} {b.VehicleColor}");
                    }
                }
            }
            Console.ResetColor();
        }
    }
    internal class Parkinggarage
    {
        internal static void CreateSpaces()
        {
            for (int i = 0; i < Program.parkingSpots.Length; i++)
            {
                Program.parkingSpots[i] = new ParkingSpot(0f);
            }
        }

        public static void ParkingStatus()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Parkeringsstatus\n");
            int x = 1;         
            foreach (ParkingSpot p in Program.parkingSpots)
            {
                Console.SetCursorPosition(0, x + 1);
                Console.Write($"{(x):D2} "); 
                p.Occupied();
                x++;
            }
        }
    }
    internal class VehiclePark
    {


    }
}
