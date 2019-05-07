namespace HornetWings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class HornetWings
    {
        public static void Main()
        {
            long wingFlap = long.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());  // meters for 1000 wingFlaps
            long endurance = long.Parse(Console.ReadLine()); // how many flaps for rest

            double rest = 5.0; // seconds
            double flapsPerSecond = 100.0;
            double metersTraveled = 0;
            double secondsPassed = 0;

            metersTraveled = (wingFlap / 1000) * distance;
            secondsPassed = (wingFlap / flapsPerSecond) + ((wingFlap / endurance) * 5.0);

            Console.WriteLine($"{metersTraveled:f2} m.");
            Console.WriteLine($"{secondsPassed} s.");
        }
    }
}
