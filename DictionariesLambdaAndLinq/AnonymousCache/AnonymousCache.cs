using System.CodeDom;

namespace AnonymousCache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class AnonymousCache
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> dataSetInfo = new Dictionary<string, Dictionary<string, long>>();

            List<string> cache = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                var commandArgs = input
                    .Split(new[] {" -> ", " | "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs.Length == 1)
                {
                    var dataSet = commandArgs[0];
                    cache.Add(dataSet);
                }
                else
                {
                    var name = commandArgs[0];
                    var size = long.Parse(commandArgs[1]);
                    var dataSet = commandArgs[2];

                    if (!dataSetInfo.ContainsKey(dataSet))
                    {
                        dataSetInfo.Add(dataSet, new Dictionary<string, long>());
                        
                    }
                         dataSetInfo[dataSet].Add(name, size);
                    
                }
            }

            if (cache.Count > 0)
            {
                var result = dataSetInfo
                    .OrderByDescending(data => data.Value.Sum(d => d.Value))
                    .First();

                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(d => d.Value)}");

                foreach (var v in result.Value)
                {
                    Console.WriteLine($"$.{v.Key}");
                }
            }
        }
    }
}
