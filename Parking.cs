using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class ParkingSpot
    {        
        public float SpotCapsity { get; }
        public float SpotUsed { get; }
        public List<Vehicle> Vehicles { get; set; }
        
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
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Upptagen ");
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
        internal static ParkingSpot[] parkingSpots = new ParkingSpot[15];
        public static void ParkingSpaces()
        {
            int x = 1;
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                parkingSpots[i] = new ParkingSpot();
            }
            foreach (ParkingSpot p in parkingSpots)
            {
                Console.Write($"{(x):D2} "); p.Occupied();
                x++;
            }
        Console.ReadLine();
        }
    }
    internal class VehiclePark
    {


    }
}
