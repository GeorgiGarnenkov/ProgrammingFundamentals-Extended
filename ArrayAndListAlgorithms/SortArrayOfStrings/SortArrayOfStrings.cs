namespace SortArrayOfStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class SortArrayOfStrings
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < input.Length - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    int cmpStrings = input[j].CompareTo(input[j - 1]);
                    if (cmpStrings < 0)
                    {
                        var temp = input[j];
                        input[j] = input[j - 1];
                        input[j - 1] = temp;
                    }
                    j--;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
