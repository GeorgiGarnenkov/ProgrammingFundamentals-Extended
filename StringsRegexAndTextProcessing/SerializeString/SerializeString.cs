using System;
using System.Collections.Generic;
namespace SerializeString
{
    public class SerializeString
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            List<char> chars = new List<char>();

            if (input != null)
            {
                foreach (var symbol in input)
                {
                    if (!chars.Contains(symbol))
                    {
                        chars.Add(symbol);
                    }
                }
                foreach (var symbol in chars)
                {
                    List<int> doublesPosition = new List<int>();
                    for (int j = 0; j < input.Length; j++)
                    {
                        var doubles = input[j];
                        if (symbol == doubles)
                        {
                            doublesPosition.Add(j);
                        }
                    }
                    Console.WriteLine($"{symbol}:{string.Join("/", doublesPosition)}");
                }
            }
        }
    }
}
