using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal static class Helpers
    {
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
        internal static void ClearBottom()
        {
            int width = Console.WindowWidth;
            string clear = new string(' ', width);
            for (int i = Program.parkingSpots.Length + 8; i < Program.parkingSpots.Length + 23; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(clear);
            }
            Console.SetCursorPosition(0, Program.parkingSpots.Length + 8);
        }
        internal static void ClearTop()
        {
            int width = Console.WindowWidth;
            string clear = new string(' ', width);
            for (int i = 0;  i < Program.parkingSpots.Length +7; i++)
            {
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(clear);
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
    }
}
