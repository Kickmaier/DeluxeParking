using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class ParkingMain
    {
        internal static void ParkingMainMenu()
        {
            Parkinggarage.CreateSpaces();

            while (true)
            {
                Parkinggarage.ParkingStatus();
                Console.WriteLine();
                MenuHelpers.DrawMainMenue();
                ConsoleKey key = Helpers.KeyLimiter();

                switch (key)
                {
                    case ConsoleKey.D1:
                        MenuHelpers.StartParkingMenu();
                        break;
                    case ConsoleKey.D2:
                        MenuHelpers.StopParkingMenu();
                        break;
                }
            }
        }
    }
}
