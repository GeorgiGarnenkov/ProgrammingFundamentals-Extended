using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    public class Exam2
    {
        public static void Main()
        {
            var originalArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var index = originalArray.Last();
            originalArray.RemoveAt(originalArray.Count - 1);

            var sequence = new List<int>();

            sequence.AddRange(originalArray);
            
            var count = 0;

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] > 0)
                {
                    sequence[i] -= 1;
                }
            }
            if (sequence[index] != 0)
            {
                if (sequence.Contains(0))
                {
                    for (int i = 0; i < sequence.Count; i++)
                    {
                        if (sequence[i] == 0)
                        {
                            sequence[i] = originalArray[i];
                        }
                    }
                    count++;
                }
                else
                {
                    count++;
                }
                
            }
            else
            {
                Console.WriteLine(string.Join(" ", sequence));
                Console.WriteLine(count);
                return;
            }


            bool isTrue = true;
            while (isTrue)
            {
                index = int.Parse(Console.ReadLine());

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] > 0)
                    {
                        sequence[i] -= 1;
                    }
                }
                if (sequence[index] != 0)
                {
                    if (sequence.Contains(0))
                    {
                        for (int i = 0; i < sequence.Count; i++)
                        {
                            if (sequence[i] == 0)
                            {
                                sequence[i] = originalArray[i];
                            }
                        }
                        count++;
                    }
                    else
                    {
                        count++;
                    }

                }
                else
                {
                    Console.WriteLine(string.Join(" ", sequence));
                    Console.WriteLine(count);
                    isTrue = false;
                    return;
                }
            }
        }
    }
}
