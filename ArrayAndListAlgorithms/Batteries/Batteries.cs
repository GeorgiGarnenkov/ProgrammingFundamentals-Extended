namespace Batteries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Batteries
    {
        public static void Main()
        {
            double[] capacities = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            double[] usagePerHour = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            int amountOfHours = int.Parse(Console.ReadLine());

            for (int i = 0; i < capacities.Length; i++)
            {
                var capacity = capacities[i];
                var usage = usagePerHour[i];

                var capacityLeft = capacity - (usage * amountOfHours);

                if (capacityLeft > 0)
                {
                    var percent = (capacityLeft * 100.0) / capacity;
                    Console.WriteLine($"Battery {i + 1}: {capacityLeft:f2} mAh ({percent:f2})%");
                }
                else
                {
                    var hoursOfUsage = (capacity / usage) + 1.0;
                    Console.WriteLine($"Battery {i + 1}: dead (lasted {Math.Floor(hoursOfUsage)} hours)");
                }
            }
        }
    }
}
