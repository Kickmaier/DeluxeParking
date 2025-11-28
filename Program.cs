namespace DeluxeParking
{
    internal class Program
    {
        internal const float spotCapasity = 1f;
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //Parkinggarage.ParkingSpaces();
            Console.WriteLine(Helpers.PlateGenerator());
            Console.WriteLine(Helpers.CarPainter());
        }
    }
}
