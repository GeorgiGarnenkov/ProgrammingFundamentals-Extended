using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsa
{
    public class Nsa
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> dictionary =
                new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "quit")
            {
                var commandArgs = input
                    .Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var country = commandArgs[0];
                var spy = commandArgs[1];
                var days = int.Parse(commandArgs[2]);

                if (!dictionary.ContainsKey(country))
                {
                    dictionary.Add(country, new Dictionary<string, int>());
                    dictionary[country].Add(spy, days);
                }
                else
                {
                    if (!dictionary[country].ContainsKey(spy))
                    {
                        dictionary[country].Add(spy, days);
                    }
                    else
                    {
                        dictionary[country][spy] = days;
                    }
                }
            }
            foreach (var kvp in dictionary.OrderByDescending(a => a.Value.Count))
            {
                Console.WriteLine($"Country: {kvp.Key}");
                foreach (var pair in kvp.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"**{pair.Key} : {pair.Value}");
                }
            }


        }
    }
}
