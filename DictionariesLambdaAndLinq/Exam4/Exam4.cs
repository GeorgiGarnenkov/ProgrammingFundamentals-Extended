using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam4
{
    public class Exam4
    {
        public static void Main()
        {
            string input;

            SortedDictionary<string, List<long>> dict = new SortedDictionary<string, List<long>>();

            while ((input = Console.ReadLine()) != "I believe I can fly!")
            {
                if (!input.Contains('='))
                {
                    var commandArgs = input
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var customerName = commandArgs[0];
                    if (!dict.ContainsKey(customerName))
                    {
                        dict.Add(customerName, new List<long>());
                    }
                    
                        for (int i = 1; i < commandArgs.Length; i++)
                        {
                            var flights = int.Parse(commandArgs[i]);
                            if (!dict[customerName].Contains(flights))
                            {
                                dict[customerName].Add(flights);
                            }
                        }
                }
                else
                {
                    var commandArgs = input
                        .Split(new[] { " = " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var customerName = commandArgs[0];
                    var otherCustomerName = commandArgs[1];
                    dict[customerName] = new List<long>();
                    dict[customerName] = dict[otherCustomerName];
                }
            }
            foreach (var kvp in dict.OrderByDescending(a => a.Value.Count()))
            {
                var list = kvp.Value.OrderBy(a => a).ToList();
                Console.WriteLine($"#{kvp.Key} ::: {string.Join(", ", list)}");
            }
        }
    }
}
