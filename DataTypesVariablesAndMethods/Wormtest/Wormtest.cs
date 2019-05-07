namespace Wormtest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wormtest
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            int lengthCM = length * 100;
            double widthCM = width;


            var reminder = lengthCM % widthCM;

            double percent = (lengthCM * 100) / widthCM;

            double sum = lengthCM * widthCM;

            if (reminder != 0 && widthCM != 0)
            {
                Console.WriteLine($"{percent:f2}%");
            }
            else if (reminder == 0)
            {
                Console.WriteLine($"{sum:f2}");
            }
            else if (lengthCM == 0 || widthCM == 0)
            {
                Console.WriteLine($"{sum:f2}");
            }
        }
    }
}
