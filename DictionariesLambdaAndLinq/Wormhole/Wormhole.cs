using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormhole
{
    public class Wormhole
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var step = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                var position = numbers[i];

                if (position == 0)
                {
                    step++;
                }else if (position > 0)
                {
                    numbers[i] = 0;
                    i = position - 1;
                }
            }
            Console.WriteLine(step);
        }
    }
}
