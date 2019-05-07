
namespace Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;


    public class Cards
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            string pattern = @"(^|(?<=[CDHS]))([23456789]|(10)|[AJKQ])([CDHS])";

            List<string> result = new List<string>();
            foreach (Match m in Regex.Matches(input, pattern))
            {
                result.Add(m.ToString());
            }

            Console.WriteLine(String.Join(", ", result));
        }
    }
}
