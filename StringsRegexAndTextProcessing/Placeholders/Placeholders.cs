namespace Placeholders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Placeholders
    {
        public static void Main()
        {
           var input = Console.ReadLine();
            while (input != "end")
            {
                var inputArray = input
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var inputString = inputArray[0];

                var placeholders = inputArray[1]
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                for (int i = 0; i < placeholders.Length; i++)
                {
                    string currentPlaceholder = "{" + i + "}";

                    inputString = inputString.Replace(currentPlaceholder, placeholders[i]);
                }
                Console.WriteLine(inputString);
                input = Console.ReadLine();
            }
        }
    }
}
