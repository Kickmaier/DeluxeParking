using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class ParkingSpot
    {
        public const float SpotCapacity = 1.0f;
        public float SpotUsed { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public ParkingSpot(float spotUsed)
        {
            SpotUsed = spotUsed;
            Vehicles = new List<Vehicle>();
        }

        internal void Occupied()
        {   
            if (SpotUsed == 0f)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ledig");
            }
            else if (SpotUsed == 0.5f)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ledig ");
                Console.ResetColor();
                foreach (Vehicle v in Vehicles)
                {
                    if (v is Motorcycle mc)
                    {
                        Console.Write($"MC {mc.LicensePlate} {mc.Brand} {mc.VehicleColor}");
                    }
                }
            }
            else if (SpotUsed == 1.0f)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Upptagen ");
                Console.ResetColor();
                foreach (Vehicle v in Vehicles)
                {
                    if (v is Motorcycle m)
                    {
                        Console.Write($"MC {m.LicensePlate} {m.Brand} {m.VehicleColor} ");
                    }
                    else if (v is Car c)
                    {
                        string engineType = c.Electric ? "Elektisk" : "Förbränning";
                        Console.Write($"Bil {c.LicensePlate} {engineType} {c.VehicleColor}");
                    }
                    else if (v is Bus b)
                    {
                        Console.Write($"Buss {b.LicensePlate} {b.Passengers} {b.VehicleColor}");
                    }
                }
            }
            Console.ResetColor();
        }
    }
    internal class ParkingGarage
    {
        internal static void CreateSpaces()
        {
            for (int i = 0; i < Program.parkingSpots.Length; i++)
            {
                Program.parkingSpots[i] = new ParkingSpot(0f);
            }
        }

        internal static void ParkingStatus()
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
        internal static void ParkVehicle(Vehicle v)
        {
            var spot = Program.parkingSpots;

            if (v is Motorcycle mc)
            {
                for (int i = 0; i < spot.Length; i++)
                {  
                    if (spot[i].SpotUsed + mc.VehicleSize <= ParkingSpot.SpotCapacity)
                    {
                        spot[i].SpotUsed += mc.VehicleSize;
                        spot[i].Vehicles.Add(mc);
                        Console.WriteLine($"Fordon med regnr {mc.LicensePlate} parkerat på plats {i + 1}");
                        return;
                    }
                }
            }
            else if (v is Car c)
            {
                for (int i = 0; i < spot.Length; i++)
                {
                    if (spot[i].SpotUsed + c.VehicleSize <= ParkingSpot.SpotCapacity)
                    {
                        spot[i].SpotUsed += c.VehicleSize;
                        spot[i].Vehicles.Add(c);
                        Console.WriteLine($"Fordon med regnr {c.LicensePlate} parkerat på plats {i + 1}");
                        return;
                    }

                }
            }
            else if(v is Bus bus)
            {
                for(int i = 0;i < spot.Length -1;i++)
                {
                    if (spot[i].SpotUsed == 0 && spot[i+1].SpotUsed == 0)
                    {
                        spot[i].SpotUsed += bus.VehicleSize/2;
                        spot[i + 1].SpotUsed += bus.VehicleSize/2;
                        spot[i].Vehicles.Add(bus);
                        spot[i+1].Vehicles.Add(bus);
                        Console.WriteLine($"Fordon med regnr {bus.LicensePlate} parkerat på plats {i + 1} och {i + 2}");
                        return;
                    }

                }
            }
            Console.WriteLine("Fordonet får tyvärr inte plats på parkeringen");
        }
        internal static void Unpark(string licence)
        {
            for (int i = 0; i < Program.parkingSpots.Length; i++)
            {
                if (Program.parkingSpots[i].Vehicles.Count > 0)
                for (int j = 0; j < Program.parkingSpots[i].Vehicles.Count; j++)
                {
                       Vehicle v = Program.parkingSpots[i].Vehicles[j];
                        if(v.LicensePlate == licence && v is not Bus)
                        {
                            Program.parkingSpots[i].SpotUsed -= v.VehicleSize;
                            Program.parkingSpots[i].Vehicles.Remove(v);
                            Console.Write(v.LicensePlate);
                            Helpers.ClearTop();
                            return; ;
                        }
                        else if (v.LicensePlate == licence && v is Bus)
                        {
                            Program.parkingSpots[i].SpotUsed -= v.VehicleSize / 2;
                            Program.parkingSpots[i+1].SpotUsed -= v.VehicleSize / 2;
                            Program.parkingSpots[i].Vehicles.Remove(v);
                            Program.parkingSpots[i+1].Vehicles.Remove(v);
                            Helpers.ClearTop();
                            return;
                        }
                }

            }
            Console.WriteLine("Kunde inte hitta fordonet");
        }
    }
}
