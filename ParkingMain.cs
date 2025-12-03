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
            ParkingGarage.CreateSpaces();

            while (true)
            {
            Helpers.HotFix();
                Console.WriteLine(
                $"Välkommen till DeluxeParking!!!\n\n" +
                $"Pris per plats 1.5kr/s (MC 0.5kr/s Bil 1.5kr/s Buss 3.0kr/s)\n\n"+
                $"Här nedan kan du göra följande val.\n\n" +
                $"Val 1. Parkera fordon.\n" +
                $"Val 2. Avsluta parkering");

                ConsoleKey key = Helpers.KeyLimiter();

                switch (key)
                {
                    case ConsoleKey.D1:
                        StartParkingMenu();
                        break;
                    case ConsoleKey.D2:
                        StopParkingMenu();
                        break;
                }
            }
        }
        internal static void StartParkingMenu()
        {
            while (true)
            {
                Console.Clear();
                Helpers.HotFix();
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
                        Thread.Sleep(1500);
                        return;
                    case ConsoleKey.D2:
                        Vehicle car = VehicleCreator.CarCreator();
                        ParkingGarage.ParkVehicle(car);
                        Thread.Sleep(1500);
                        return;
                    case ConsoleKey.D3:
                        Vehicle bus = VehicleCreator.BusCreator();
                        ParkingGarage.ParkVehicle(bus);
                        Thread.Sleep(1500);
                        return;
                    case ConsoleKey.Q:
                        Console.WriteLine("Återgår");
                        Thread.Sleep(1500);
                        return;
                }
            }
        }

        internal static void StopParkingMenu()
        {
            Helpers.HotFix();
            Console.WriteLine("Ange registreringsnummer för det fordon du vill checka ut!");

            string license = Console.ReadLine();
            license = license.ToUpper();
            while (true)
            {
                if (Helpers.VehicleFinder(license) != null)
                {
                    Console.WriteLine($"Är detta fordonet du vill ckecka ut?\n\n" +
                        $"{Helpers.VehicleFinder(license).LicensePlate}\n\n" +
                        $"'Y' för ja\n'N' för nej");
                }
                else
                {
                    Console.WriteLine("Kunde inte hitta fordonet");
                    Thread.Sleep(1500);
                    return;
                }
                    ConsoleKey key = Helpers.KeyLimiter();

                switch (key)
                {
                    case ConsoleKey.Y:
                        ParkingGarage.Unpark(license);
                        Thread.Sleep(1500);
                        return;
                    case ConsoleKey.N:
                        Console.Write("Var god börja om utcheckningen");
                        Thread.Sleep(1500);
                        return;
                }
            }

        }
    }
}
