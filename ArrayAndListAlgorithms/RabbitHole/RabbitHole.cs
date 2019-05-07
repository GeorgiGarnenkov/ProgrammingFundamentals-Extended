using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHole
{
    public class RabbitHole
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .ToList();
            var energy = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Count; i++)
            {
                var position = array[i];

                if (position.Contains("RabbitHole"))
                {

                }
                else if (position.Contains("Left"))
                {
                    var command = position.Split('|').ToArray();
                    var leftJumps = int.Parse(command[1]);

                    
                    
                }
                else if (position.Contains("Right"))
                {
                    var command = position.Split('|').ToArray();
                    var rightJumps = int.Parse(command[1]);


                }
                else if (position.Contains("Bomb"))
                {
                    var command = position.Split('|').ToArray();
                    var bomb = int.Parse(command[1]);



                }
            }
            Console.WriteLine();
        }
    }
}
