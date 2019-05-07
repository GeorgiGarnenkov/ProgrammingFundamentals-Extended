namespace InsertionSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InsertionSort
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(Int32.Parse)
                .ToArray();

            for (int i = 0; i < array.Length - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (array[j] < array[j - 1])
                    {
                        var temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    j--;
                }
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
