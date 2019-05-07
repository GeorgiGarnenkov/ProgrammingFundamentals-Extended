
using System.Diagnostics;

namespace PokeMon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PokeMon
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var m = long.Parse(Console.ReadLine());

            var y = long.Parse(Console.ReadLine());

            var nInHalft = n / 2;

            var counter = 0;

            bool isTrue = true;
            while (isTrue)
            {
                n -= m;

                if (n == nInHalft && y > 0)
                {
                    n /= y;
                }

                counter++;

                if (n < m)
                {
                    isTrue = false;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}
