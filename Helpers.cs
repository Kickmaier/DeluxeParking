using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Helpers
    {
        static Random rnd = new Random();

        internal static string PlateGenerator()
        {
            char[] plateLetters =
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U',
             'V', 'X', 'Y', 'Z'
            };
            string letters = "";
            for (int i = 0; i < 3; i++)
            {
                letters += plateLetters[rnd.Next(plateLetters.Length)];
            }
            string numbers = "";
            for (int i = 0; i < 3; i++)
            {
                numbers += rnd.Next(0, 10);
            }
            return $"{letters}{numbers}";
        }
        internal static string VehiclePainter()
        {
            string[] colors = { "Röd", "Blå", "Grön", "Svart", "Vit", "Gul", "Silver", "Orange", "Lila", "Rosa" };
            return colors[rnd.Next(colors.Length)];
        }
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
            for (int i = 17; i < 30; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(Program.screenClear);
            }
            Console.SetCursorPosition(0, 20);
        }
    }
}
