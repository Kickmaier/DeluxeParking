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
        internal string LicensePlate { get; private set; }
        internal string VehicleColor { get; set; }
        internal DateTime ParkedTime { get; private set; }
        internal abstract float VehicleSize { get; }

        protected Vehicle(string licensePlate, string vehicleColor, DateTime parkedTime)
        {
            LicensePlate = licensePlate;
            VehicleColor = vehicleColor;
            ParkedTime = parkedTime;
        }
    }
    internal class Motorcycle : Vehicle
    {
        internal string Brand { get; set; }

        public Motorcycle(string licensePlate, string vehicleColor, DateTime parkedTime, string brand) : base(licensePlate, vehicleColor, parkedTime) 
        { 
            Brand = brand;
        } 
        internal override float VehicleSize { get; } = 0.5f;
    }
    internal class Car : Vehicle
    {
        internal bool Electric { get; set; }
        public Car(string licensePlate, string vehicleColor, DateTime parkedTime, bool electric) : base(licensePlate, vehicleColor, parkedTime)
        { 
        Electric = electric;
        }  
        internal override float VehicleSize { get; } = 1.0f;
    }
    internal class Bus : Vehicle
    {
        internal int Passengers { get; set; }
        public Bus(string licensePlate, string vehicleColor, DateTime parkedTime, int passengers ) : base(licensePlate, vehicleColor, parkedTime) 
        { 
            Passengers = passengers;
        }
        internal override float VehicleSize { get; } = 2.0f;
    }
}
