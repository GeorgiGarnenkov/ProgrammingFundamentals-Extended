using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exam3
{
    public class Exam3
    {
        public static void Main()
        {
            var type = new List<string>();
            var source = new List<string>();
            var forecast = new List<string>();

            string input;

            var regexType = @"^Type: (Normal|Danger|Warning)$";
            var regexSource = @"^Source: ([A-Za-z0-9]+)$";
            var regexForecast = @"^Forecast: ([^.,?!]+)$";
            
            var nextCommand = "Type";

            while ((input = Console.ReadLine()) != "Davai Emo")
            {
                if (Regex.IsMatch(input, regexType) 
                    || Regex.IsMatch(input, regexSource) 
                    || Regex.IsMatch(input, regexForecast))
                {
                    var line = input
                        .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var command = line[0];
                    var text = line[1];

                    if (command == nextCommand)
                    {
                        if (command == "Type")
                        {
                            type.Add(text);
                            nextCommand = "Source";
                        }
                        else if (command == "Source")
                        {
                            source.Add(text);
                            nextCommand = "Forecast";
                        }
                        else if (command == "Forecast")
                        {
                            forecast.Add(text);
                            nextCommand = "Type";
                        }
                    }
                }
            }
            for (int i = 0; i < type.Count; i++)
            {
                Console.WriteLine($"({type[i]}) {forecast[i]} ~ {source[i]}");
            }
        }
    }
}
