using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    abstract class Vehicle
    {
        public string LicensePlate { get; set; }
        public string VehicleColor { get; set; }
        public abstract float VehicleSize { get; }

        protected Vehicle(string licensePlate, string vehicleColor)
        {
            LicensePlate = licensePlate;
            VehicleColor = vehicleColor;
        }
    }

    internal class Motorcycle : Vehicle
    {
        public string Brand { get; set; }

        public Motorcycle(string licensePlate, string vehicleColor, string brand) : base(licensePlate, vehicleColor) 
        { 
            Brand = brand;
        }
        
        public override float VehicleSize { get; } = 0.5f;
    }
    internal class Car : Vehicle
    {
        public bool Electric { get; set; }
        public Car(string licensePlate, string vehicleColor, bool electric) : base(licensePlate, vehicleColor)
        { 
        Electric = electric;
        }

        
        public override float VehicleSize { get; } = 1.0f;
    }
    internal class Bus : Vehicle
    {
        public int Passengers { get; set; }
        public Bus(string licensePlate, string vehicleColor, int passengers ) : base(licensePlate, vehicleColor) 
        { 
            Passengers = passengers;
        }
        
        public override float VehicleSize { get; } = 2;
    }
}
