namespace PointsCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class PointsCounter
    {
        public static void Main()
        {
            string input;
            Dictionary<string, Dictionary<string, int>> teams = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "Result")
            {
                var inputArgs = input
                    .Split('|')
                    .ToArray();
                var inputArgsZero = InputArgsZero(inputArgs);
                var inputArgsOne = InputArgsOne(inputArgs);
                var inputArgsTwo = inputArgs[2];

                var teamName = "";
                var player = "";
                var points = 0;
                if (char.IsUpper(inputArgsZero[1]))
                {
                    teamName = inputArgsZero;
                    player = inputArgsOne;
                    points = int.Parse(inputArgsTwo);
                }
                else
                {
                    teamName = inputArgsOne;
                    player = inputArgsZero;
                    points = int.Parse(inputArgsTwo);
                }
                if (!teams.ContainsKey(teamName))
                {
                    teams.Add(teamName, new Dictionary<string, int>());
                }
                if (!teams[teamName].ContainsKey(player))
                {
                    teams[teamName].Add(player, 0);
                }
                teams[teamName][player] = points;
            }

            foreach (var team in teams.OrderByDescending(s => s.Value.Values.Sum()))
            {
                Console.WriteLine($"{team.Key} => {team.Value.Values.Sum()}");
                foreach (var player in team.Value.OrderByDescending(s => s.Value).Take(1))
                {
                    Console.WriteLine($"Most points scored by {player.Key}");
                }
            }
        }

        static string InputArgsOne(string[] inputArgs)
        {
            StringBuilder one = new StringBuilder();
            for (int i = 0; i < inputArgs[1].Length; i++)
            {
                var argsZero = inputArgs[1];
                if (argsZero[i] != '@' &&
                    argsZero[i] != '%' &&
                    argsZero[i] != '$' &&
                    argsZero[i] != '*' &&
                    argsZero[i] != '&')
                {
                    one.Append(argsZero[i]);
                }
            }
            return one.ToString();
        }

        static string InputArgsZero(string[] inputArgs)
        {
            StringBuilder zero = new StringBuilder();
            for (int i = 0; i < inputArgs[0].Length; i++)
            {
                var argsZero = inputArgs[0];
                if (argsZero[i] != '@' &&
                    argsZero[i] != '%' &&
                    argsZero[i] != '$' &&
                    argsZero[i] != '*' &&
                    argsZero[i] != '&')
                {
                    zero.Append(argsZero[i]);
                }
            }
            return zero.ToString();
        }
    }
}
