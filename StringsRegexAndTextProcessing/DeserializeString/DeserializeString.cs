using System.Runtime.CompilerServices;

namespace DeserializeString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeserializeString
    {
        public static void Main()
        {
            SortedDictionary<int, char> result = new SortedDictionary<int, char>();
            while (true)
            {
                var array = Console.ReadLine()
                    .Split(':')
                    .ToArray();
                if (array[0] == "end")
                {
                    break;
                }
                char letter = array[0][0];
                int[] indexes = array[1]
                    .Split('/')
                    .Select(int.Parse)
                    .ToArray();
                foreach (var index in indexes)
                {
                    result[index] = letter;
                }
            }
            Console.WriteLine(result.Values.ToArray());
        }
    }
}
