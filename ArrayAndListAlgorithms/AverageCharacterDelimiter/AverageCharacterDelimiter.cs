using System.Diagnostics.CodeAnalysis;

namespace AverageCharacterDelimiter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class AverageCharacterDelimiter
    {
        public static void Main()
        {
            var inputString = Console.ReadLine()
                .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var join = string.Join("", inputString);
            char[] chars = join.ToCharArray();

            int sum = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                sum += chars[i];
            }

            var delimiter = sum / chars.Length;

            var delimiterSymbol = (char)delimiter;

            if (Char.IsLetter(delimiterSymbol))
            {
                delimiterSymbol = Char.ToUpper(delimiterSymbol);
            }
            
            Console.WriteLine(string.Join($"{delimiterSymbol}", inputString));

        }
    }
}
