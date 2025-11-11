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
        public Motorcycle(string licensePlate, string vehicleColor) : base(licensePlate, vehicleColor) { }
        public string Brand { get; set; }
        public override float VehicleSize { get; } = 0.5f;
    }
    internal class Car : Vehicle
    {
        public Car (string licensePlate, string vehicleColor) : base (licensePlate, vehicleColor) { }

        public bool Electric { get; set; }
        public override float VehicleSize { get; } = 1.0f;
    }
    internal class Bus : Vehicle
    {
        public Bus(string licensePlate, string vehicleColor) : base(licensePlate, vehicleColor) { }
        public int Passengers { get; set; }
        public override float VehicleSize { get; } = 2;
    }
}
