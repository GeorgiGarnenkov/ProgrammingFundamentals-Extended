namespace BubbleSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class BubbleSort
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(Int32.Parse)
                .ToArray();

            PrintBubbleSort(array);
        }

        static void PrintBubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var num = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = num;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", array));
        }
    }
}
