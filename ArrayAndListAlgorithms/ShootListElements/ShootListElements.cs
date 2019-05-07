using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootListElements
{
    class ShootListElements
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();
            string input;
            var lastRemovedElement = 0;
            while ((input = Console.ReadLine()) != "stop")
            {
                var commandArgs = input;
                if (commandArgs == "bang")
                {
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"nobody left to shoot! last one was {lastRemovedElement}");
                        return;
                    }
                    else
                    {
                        var averageNum = numbers.Average();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= averageNum)
                            {
                                Console.WriteLine($"shot {numbers[i]}");
                                lastRemovedElement = numbers[i];
                                numbers.RemoveAt(i);
                                break;
                            }
                        }
                        if (numbers.Count > 0)
                        {
                            DecrementEveryElement(numbers);
                        }
                    }
                }
                else
                {
                    int num = int.Parse(commandArgs);
                    numbers.Insert(0, num);
                }
            }
            if (numbers.Count > 0)
            {
                Console.WriteLine($"survivors: {String.Join(" ", numbers)}");
            }
            else
            {
                Console.WriteLine($"you shot them all. last one was {lastRemovedElement}");
            }
        }

        private static void DecrementEveryElement(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }
    }
}
