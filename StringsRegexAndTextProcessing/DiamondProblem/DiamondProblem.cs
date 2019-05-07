using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondProblem
{
    class DiamondProblem
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var startIndex = -1;
            var endIndex = 0;
            bool isTrue = false;
            while ((startIndex = input.IndexOf('<', startIndex + 1)) != -1 &&
                   (endIndex = input.IndexOf('>', startIndex + 1)) != -1)
            {
                isTrue = true;
                var diamond = input.Substring(startIndex + 1, endIndex - startIndex - 1);
                var sum = 0;
                foreach (char d in diamond)
                {
                    if (char.IsDigit(d))
                    {
                        sum += int.Parse(d.ToString());
                    }
                }
                Console.WriteLine($"Found {sum} carat diamond");
            }
            if (!isTrue)
            {
                Console.WriteLine("Better luck next time");
            }
        }
    }
}
