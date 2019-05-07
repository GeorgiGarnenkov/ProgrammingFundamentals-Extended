namespace FlattenDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class FlattenDictionary
    {
        public static void Main()        //    >>>>>    80 / 100    <<<<<
        {
            Dictionary<string, Dictionary<string, string>> dictionary =
                new Dictionary<string, Dictionary<string, string>>();

            Dictionary<string, List<string>> flatKeys =
                new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                var commandArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs.Length == 2)
                {
                    var keyForFlat = commandArgs[1];

                    foreach (var kvp in dictionary[keyForFlat])
                    {
                        if (!flatKeys.ContainsKey(keyForFlat))
                        {
                            flatKeys.Add(keyForFlat, new List<string>());
                        }
                        flatKeys[keyForFlat].Add(kvp.Key + kvp.Value);
                    }
                    dictionary.Remove(keyForFlat);
                }
                else if (commandArgs.Length == 3)
                {
                    var mainKey = commandArgs[0];
                    var innerKey = commandArgs[1];
                    var innerValue = commandArgs[2];

                    if (!dictionary.ContainsKey(mainKey))
                    {
                        dictionary.Add(mainKey, new Dictionary<string, string>());
                    }

                    if (!dictionary[mainKey].ContainsKey(innerKey))
                    {
                        dictionary[mainKey].Add(innerKey, innerValue);
                    }
                    else
                    {
                        dictionary[mainKey][innerKey] = innerValue;
                    }
                }
            }
            foreach (var main in dictionary.OrderByDescending(a => a.Key.Length))
            {
                Console.WriteLine(main.Key);
                var counter = 1;
                foreach (var m in main.Value.OrderBy(a => a.Key.Length))
                {
                    Console.WriteLine($"{counter++}. {m.Key} - {m.Value}");
                }
                if (flatKeys.ContainsKey(main.Key))
                {
                    foreach (var flatKeysValue in flatKeys.Values)
                    {
                        foreach (var value in flatKeysValue)
                        {
                            Console.WriteLine($"{counter++}. {value}");
                        }
                    }
                }
            }
        }
    }
}
