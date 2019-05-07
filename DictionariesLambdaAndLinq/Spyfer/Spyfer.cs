using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spyfer
{
    public class Spyfer
    {
        public static void Main()
        {
            var nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            if (nums.Count == 0)
            {
                return;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                var numSum = nums[i];
                
                if (i != 0 && i != nums.Count - 1)
                {
                    if (numSum == nums[i - 1] + nums[i + 1])
                    {
                        nums.RemoveAt(i + 1);

                        nums.RemoveAt(i - 1);

                        i = 0;
                    }
                }

                else if (i == 0 && numSum == nums[i + 1])
                {
                    nums.RemoveAt(i + 1);
                    i = 0;
                }

                else if (i == nums.Count - 1 && numSum == nums[i - 1])
                {
                    nums.RemoveAt(i - 1);
                    i = 0;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
