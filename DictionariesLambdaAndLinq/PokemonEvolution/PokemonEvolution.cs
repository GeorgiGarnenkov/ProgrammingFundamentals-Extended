namespace PokemonEvolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pokemon
    {
        public string Name { get; set; }

        public string Evolution { get; set; }

        public long Power { get; set; }
    }

    public class PokemonEvolution
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            List<Pokemon> pokemons = new List<Pokemon>();

            bool isTrue = true;
            while (isTrue)
            {

                string[] commandArgs = line
                    .Split(new [] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    string evolution = commandArgs[1];
                    long power = long.Parse(commandArgs[2]);

                    Pokemon pokemon = new Pokemon
                    {
                        Name = name,
                        Evolution = evolution,
                        Power = power
                    };

                    pokemons.Add(pokemon);
                }

                if (commandArgs.Length == 1)
                {
                    var currentName = commandArgs[0];
                    var currentPokemon = pokemons.Where(p => p.Name == currentName).FirstOrDefault();

                    if (currentPokemon != null)
                    {
                        Console.WriteLine($"# {currentName}");

                        foreach (var pokemon in pokemons.Where(p => p.Name == currentName))
                        {
                            Console.WriteLine($"{pokemon.Evolution} <-> {pokemon.Power}");
                        }
                    }


                }
                if (line == "wubbalubbadubdub")
                {
                    foreach (var namee in pokemons
                        .Select(p => p.Name)
                        .Distinct()
                        .ToList())
                    {
                        Console.WriteLine($"# {namee}");
                        foreach (var evolutionn in pokemons
                            .Where(p => p.Name == namee)
                            .OrderByDescending(p => p.Power))
                        {
                            Console.WriteLine($"{evolutionn.Evolution} <-> {evolutionn.Power}");
                        }
                    }
                    isTrue = false;
                }

                line = Console.ReadLine();
            }
        }
    }
}

