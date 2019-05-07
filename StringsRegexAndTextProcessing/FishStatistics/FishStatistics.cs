namespace FishStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;


    public class FishStatistics
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(\>*)<(\(+)(['x-])>";

            MatchCollection fish = Regex.Matches(input, pattern);

            if (fish.Count == 0)
            {
                Console.WriteLine("No fish found.");
            }
            else
            {
                var counter = 1;
                foreach (Match f in fish)
                {
                    Console.WriteLine($"Fish {counter}: {f}");
                    var tail = f.Groups[1];
                    var body = f.Groups[2];
                    var status = f.Groups[3];
                    if (tail.Length >= 0)
                    {
                        if (tail.Length > 5)
                        {
                            Console.WriteLine($"Tail type: Long ({tail.Length * 2} cm)");
                        }
                        else if (tail.Length > 1 && tail.Length <= 5)
                        {
                            Console.WriteLine($"Tail type: Medium ({tail.Length * 2} cm)");
                        }
                        else if (tail.Length == 1)
                        {
                            Console.WriteLine($"Tail type: Short ({tail.Length * 2} cm)");
                        }
                        else
                        {
                            Console.WriteLine($"Tail type: None");
                        }
                    }
                    if (body.Length >= 0)
                    {
                        if (body.Length > 10)
                        {
                            Console.WriteLine($"Body type: Long ({body.Length * 2} cm)");
                        }
                        else if (body.Length > 5 && body.Length <= 10)
                        {
                            Console.WriteLine($"Body type: Medium ({body.Length * 2} cm)");
                        }
                        else if (body.Length <= 5)
                        {
                            Console.WriteLine($"Body type: Short ({body.Length * 2} cm)");
                        }
                    }
                    if (status.ToString() == "'")
                    {
                        Console.WriteLine("Status: Awake");
                    }
                    if (status.ToString() == "-")
                    {
                        Console.WriteLine("Status: Asleep");
                    }
                    if (status.ToString() == "x")
                    {
                        Console.WriteLine("Status: Dead");
                    }
                    counter++;
                }
            }
            
        }
    }
}
