using System.Reflection.Metadata;

namespace DeluxeParking
{
    internal class Program
    {
        internal static readonly ParkingSpot[] parkingSpots = new ParkingSpot[15];
        internal const float spotCapasity = 1f;
        internal const string screenClear = "                                                                       ";
        static void Main(string[] args)
        {
            Random rnd = new Random();
            ParkingMain.ParkingMainMenu();
        }
    }
}
