using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixOscarRomeoNovember
{
    public class PhoenixOscarRomeoNovember
    {
        public static void Main()
        {
            string input;

            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();
            List<string> check = new List<string>();
            while ((input = Console.ReadLine()) != "Blaze it!")
            {
                var commandArgs = input
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var creature = commandArgs[0];
                var squadMate = commandArgs[1];
                check.Add(squadMate + "" + creature);

                if (!dict.ContainsKey(creature))
                {
                    dict.Add(creature, new HashSet<string>());
                }

                if (creature == squadMate || check.Contains(creature + "" + squadMate))
                {
                    dict[squadMate].Remove(creature);
                }
                else
                {
                    dict[creature].Add(squadMate);
                }
            }
            foreach (var kvp in dict.OrderByDescending(a => a.Value.Count))
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value.Count}");
            }
        }
    }
}