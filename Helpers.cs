using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Helpers
    {
        static Random rnd = new Random();
        internal static string PlateGenerator()
        {
            char[] plateLetters = new char[]
            {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U',
             'V', 'X', 'Y', 'Z'
            };
            string letters = "";
            for (int i = 0; i < 3 ; i++)
            {
                letters += plateLetters[rnd.Next(plateLetters.Length)]; 
            }
            string numbers = "";
            for (int i = 0; i < 3; i++)
            {
                numbers += rnd.Next(1, 10);
            }
            return $"{letters} {numbers}";
        }
        internal static string CarPainter()
        {
            string[] colors = { "Röd", "Blå", "Grön", "Svart", "Vit", "Gul", "Silver", "Orange", "Lila", "Rosa" };
            return colors[rnd.Next(colors.Length)];
            
        }
    }
}
