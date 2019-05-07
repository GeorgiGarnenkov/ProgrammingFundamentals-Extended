using System;
using System.Collections.Generic;
using System.Linq;

namespace WormsWorldParty
{
    public class WormsWorldParty
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> wormTeams =
                new Dictionary<string, Dictionary<string, long>>();

            string input;

            while ((input = Console.ReadLine()) != "quit")
            {
                if (input != null)
                {
                    var commandArgs = input
                        .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var team = commandArgs[1];
                    var worm = commandArgs[0];
                    var score = long.Parse(commandArgs[2]);

                    
                    bool isContained = false;
                    foreach (var kvp in wormTeams)
                    {
                        if (kvp.Value.ContainsKey(worm))
                        {
                            isContained = true;
                        }
                    }
                    if (!isContained)
                    {
                        if (!wormTeams.ContainsKey(team))
                        {
                            wormTeams.Add(team, new Dictionary<string, long>());
                        }
                        wormTeams[team].Add(worm, 0);
                        wormTeams[team][worm] += score;
                    }
                }
            }
            var counter = 1;
            foreach (var kvp in wormTeams
                .OrderByDescending(a => a.Value.Values.Sum())
                .ThenByDescending(a => a.Value.Values.Sum() / a.Value.Keys.Count))
            {
                Console.WriteLine($"{counter++}. Team: {kvp.Key} - {kvp.Value.Values.Sum()}");

                foreach (var worm in kvp.Value
                    .OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
            }
        }
    }
}
