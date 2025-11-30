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
            Console.WriteLine(
                $"Välkommen till DeluxeParking!!!\n\n" +
                $"Här nedan kan du göra följande val.\n\n" +
                $"Val 1. Parkera fordon.\n" +
                $"Val 2. Avsluta parkering");
        }
        internal static void StartParkingMenu()
        {
            Helpers.ClearBottom();
            Console.WriteLine(
                $"Här måste du ange fordonstyp att parkera!\n\n" +
                $"Val 1. Motorcykel.\n" +
                $"Val 2. Personbil.\n" +
                $"Val 3. Buss\n\n" +
                $"Tryck 'Q' föratt återgå");

            ConsoleKey key = Helpers.KeyLimiter();

            switch (key)
            {
                case ConsoleKey.D1:
                    Vehicle mc = VehicleCreator.MotorcycleCreator();
                    ParkingGarage.ParkVehicle(mc);
                    Thread.Sleep(2000);
                    break;
                case ConsoleKey.D2:
                    Vehicle car = VehicleCreator.CarCreator();
                    ParkingGarage.ParkVehicle(car);
                    Thread.Sleep(2000);
                    break;
                case ConsoleKey.D3:
                    Vehicle bus = VehicleCreator.BusCreator();
                    ParkingGarage.ParkVehicle(bus);
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine("Återgår");
                    Thread.Sleep(2000);
                    return;
            }
            Thread.Sleep(2000);
            return;
        }
        internal static void StopParkingMenu()
        {
            Helpers.ClearBottom();
            Console.WriteLine("Ange registreringsnummer för det fordon du vill checka ut!");
            string checkout = Console.ReadLine();
            checkout = checkout.ToUpper();
            Helpers.ClearBottom();
            while (true)
            {
                Helpers.ClearBottom();
                Console.WriteLine(
                    $"Är detta fordonet du vill ckecka ut?\n\n" +
                    $"{ checkout}\n\n" +
                    $"'Y' för ja\n'N' för nej");

                ConsoleKey key = Helpers.KeyLimiter();

                switch (key)
                {
                    case ConsoleKey.Y:
                        ParkingGarage.Unpark(checkout);
                        Thread.Sleep(2000);
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
