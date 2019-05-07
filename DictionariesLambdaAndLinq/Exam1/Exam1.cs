using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Exam1
{
    public class Exam1
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            decimal density = decimal.Parse(Console.ReadLine());
            if (n < 0)
            {
                return;
            }
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                var region = Console.ReadLine()
                    .Split()
                    .Select(decimal.Parse)
                    .ToArray();

                decimal raindropsCount = region[0];
                decimal squareMeters = region[1];

                if (squareMeters > 0)
                {
                    decimal divide = raindropsCount / squareMeters;
                    sum += divide;
                }
            }
            decimal result = sum;

            if (density > 0)
            {
                 result /= density;
            }

            Console.WriteLine($"{result:f3}");
        }
    }
}
