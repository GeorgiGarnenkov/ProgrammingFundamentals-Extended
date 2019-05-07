using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainlands
{
    public class Trainlands
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> dict =
                new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "It's Training Men!")
            {
                if (input.Contains("->") && input.Contains(":"))
                {
                    var commandArgs = input.Split(new[] { " -> ", " : " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var name = commandArgs[0];
                    var wagon = commandArgs[1];
                    var power = int.Parse(commandArgs[2]);

                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, new Dictionary<string, int>());
                        dict[name].Add(wagon, power);
                    }
                    else
                    {
                        dict[name].Add(wagon, power);
                    }
                }

                else if (input.Contains("->") && !input.Contains(":"))
                {
                    var commandArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var train = commandArgs[0];
                    var trainForDel = commandArgs[1];

                    if (dict.ContainsKey(train))
                    {
                        foreach (var i in dict[trainForDel])
                        {
                            dict[train].Add(i.Key, i.Value);
                        }
                        dict.Remove(trainForDel);
                    }
                    else
                    {
                        dict.Add(train, new Dictionary<string, int>());
                        foreach (var i in dict[trainForDel])
                        {
                            dict[train].Add(i.Key, i.Value);
                        }
                        dict.Remove(trainForDel);
                    }
                }

                else if (input.Contains("="))
                {
                    var commandArgs = input.Split(new[] { " = " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var train = commandArgs[0];
                    var trainForCopi = commandArgs[1];

                    if (dict.ContainsKey(train))
                    {
                        dict[train] = new Dictionary<string, int>();
                        foreach (var i in dict[trainForCopi])
                        {
                            dict[train].Add(i.Key, i.Value);
                        }
                    }
                    else
                    {
                        dict.Add(train, new Dictionary<string, int>());
                        foreach (var i in dict[trainForCopi])
                        {
                            dict[train].Add(i.Key, i.Value);
                        }
                    }
                }
            }
            foreach (var kvp in dict
                .OrderByDescending(a => a.Value.Values.Sum())
                .ThenBy(a => a.Value.Keys.Count))
            {
                Console.WriteLine($"Train: {kvp.Key}");
                foreach (var i in kvp.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"###{i.Key} - {i.Value}");
                }
            }
        }
    }
}
