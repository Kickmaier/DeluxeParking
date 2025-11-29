using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class MenuHelpers
    {
        internal static void DrawMainMenue()
        {
            Helpers.ClearBottom();
            Console.WriteLine("Välkommen till DeluxeParking!!!\n\nHär nedan kan du göra följande val.\n\n" +
            "Val 1. Parkera fordon.\nVal 2. Avsluta parkering");
        }
        internal static void StartParkingMenu()
        {
            Helpers.ClearBottom();
            Console.WriteLine("Här måste du ange fordonstyp att parkera!\n\n" +
                "Val 1. Motorcykel.\nVal 2. Personbil.\nVal 3. Buss\n\nTryck 'Q' föratt återgå");

            ConsoleKey key = Helpers.KeyLimiter();

            switch (key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.Q:
                    return;
            }
            return;
        }
        internal static void StopParkingMenu()
        {
            Helpers.ClearBottom();
            Console.WriteLine("Ange registreringsnummer för det fordon du vill checka ut!");
            string checkout = Console.ReadLine();
            checkout = checkout.ToUpper();

            while (true)
            {
                Helpers.ClearBottom();
                Console.WriteLine("Är detta fordonet du vill ckecka ut?\n\n" + checkout + "\n\n'Y' för ja\n'N' för nej");

                ConsoleKey key = Helpers.KeyLimiter();

                switch (key)
                {
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.N:
                        Console.Write("Var god börja om utcheckningen");
                        Thread.Sleep(2000);
                        return;
                }
            }
        }
    }
}
