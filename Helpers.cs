using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal static class Helpers
    {
        internal const decimal spotPrice = 1.5m;
        internal static ConsoleKey KeyLimiter()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.Y || key.Key == ConsoleKey.N || key.Key == ConsoleKey.Q)
                {
                    return key.Key;
                }
            }
        }
        internal static string FreeSpotsCounter()
        {
            int CarCount = 0;
            int MotorcycleCount = 0;
            int busCount = 0;
            for (int i = 0; i < Program.parkingSpots.Length; i++)
            {
                if (Program.parkingSpots[i].SpotUsed == 0)
                {
                    CarCount++;
                    MotorcycleCount += 2;
                }
                else if (Program.parkingSpots[i].SpotUsed == 0.5f)
                {
                    MotorcycleCount++;
                }
            }
            for (int i = 0; i < Program.parkingSpots.Length - 1; i++)
            {
                if (Program.parkingSpots[i].SpotUsed == 0 && Program.parkingSpots[i + 1].SpotUsed == 0)
                {
                    busCount++;
                    i++;
                }
            }
            return
                $"Just \n{(MotorcycleCount):D2} platser för MC eller" +
                $"\n{(CarCount):D2} platser för bilar eller" +
                $"\n{(busCount):D2} platser för bussar.";
        }
        internal static void HotFix()
        {
            Console.Clear();
            ParkingGarage.ParkingStatus();
            Console.WriteLine();
            Console.WriteLine($"{Helpers.FreeSpotsCounter()}");
            Console.WriteLine();
        }
        internal static string PriceCalculator(DateTime d, decimal vPrice)
        {
            int time = (int)(DateTime.Now - d).TotalSeconds;
            decimal price = time * vPrice;
            string priceFormat = price.ToString("F2");
            return priceFormat;
        }
        internal static Vehicle VehicleFinder(string licence)
        {
            for (int i = 0; i < Program.parkingSpots.Length; i++)
            {
                if (Program.parkingSpots[i].Vehicles.Count > 0)
                {
                    for (int j = Program.parkingSpots[i].Vehicles.Count - 1; j >= 0; j--)
                    {

                        Vehicle v = Program.parkingSpots[i].Vehicles[j];
                        if (v.LicensePlate == licence)
                        {
                            return v; 
                        }
                    }
                }
            }
            return null;
        }
    }
}
