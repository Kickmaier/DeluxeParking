using System.Reflection.Metadata;

namespace DeluxeParking
{
    internal class Program
    {
        internal static readonly ParkingSpot[] parkingSpots = new ParkingSpot[15];
        static void Main(string[] args)
        {
            ParkingMain.ParkingMainMenu();
        }
    }
}
