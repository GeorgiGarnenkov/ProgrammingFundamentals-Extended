using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
    public class Ladybugs
    {
        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var field = new int[fieldSize];
            var ladybugsPositions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < field.Length; i++)
                for (int j = 0; j < ladybugsPositions.Length; j++)
                    if (i == ladybugsPositions[j])
                        field[i] = 1;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var commandArgs = input.Split().ToArray();
                var index = int.Parse(commandArgs[0]);
                var direction = commandArgs[1];
                var steps = int.Parse(commandArgs[2]);

                if (index < 0 || index > field.Length - 1 || field[index] == 0 || steps == 0)
                {
                    continue;
                }

                field[index] = 0;

                if (direction == "right")
                {
                    FlyRight(field, index, steps);
                }
                else if (direction == "left")
                {
                    FlyLeft(field, index, steps);
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }

        private static void FlyLeft(int[] field, int index, int steps)
        {
            for (int i = 1; i <= index + 1; i++)
            {
                var flightDistance = i * steps;

                if (index - flightDistance < 0)
                {
                    break;
                }
                if (field[index - flightDistance] == 0)
                {
                    field[index - flightDistance] = 1;
                    break;
                }
            }
        }

        private static void FlyRight(int[] field, int index, int steps)
        {
            for (int i = 1; i < field.Length - index; i++)
            {
                var flightDictance = i * steps;

                if (index + flightDictance > field.Length - 1)
                {
                    break;
                }
                if (field[index + flightDictance] == 0)
                {
                    field[index + flightDictance] = 1;
                    break;
                }
            }
        }
    }
}
