

namespace AnonymousVox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    public class AnonymousVox
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var placeholders = Console.ReadLine()
                .Split(new[] {"{", "}"},StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([A-Za-z0-9]+)(.*)\1";
           
            MatchCollection collection = Regex.Matches(text, pattern);
            
            for (var i = 0; i < collection.Count; i++)
            {
                Match m = collection[i];

                var strings = m.Value.Replace(m.Groups[2].ToString(), placeholders[i]);

                text = text.Replace(m.Value, strings);
            }

            Console.WriteLine(text);
        }
    }
}
