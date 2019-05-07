namespace Icarus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Icarus
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var startIndex = int.Parse(Console.ReadLine());

            int power = 1;
            var j = startIndex;

            string input;
            while ((input = Console.ReadLine()) != "Supernova")
            {
                var commandArgs = input.Split(' ').ToArray();

                var direction = commandArgs[0];
                var steps = int.Parse(commandArgs[1]);

                if (direction == "left")
                {
                    while (steps-- > 0)
                    {
                        if (j == 0)
                        {
                            j = array.Length - 1;
                            power++;
                            array[j] -= power;
                            continue;
                        }
                        j--;
                        array[j] -= power;
                    }
                }
                else if (direction == "right")
                {
                    while (steps-- > 0)
                    {
                        if (j == array.Length - 1)
                        {
                            j = 0;
                            power++;
                            array[j] -= power;
                            continue;
                        }
                        j++;
                        array[j] -= power;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
