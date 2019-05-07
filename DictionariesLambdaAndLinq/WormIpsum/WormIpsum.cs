using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WormIpsum
{
    public class WormIpsum
    {
        public static void Main()
        {
            var pattern = @"^[A-Z][^\.]*\.$";
            Regex regex = new Regex(pattern);

            string input;

            while ((input = Console.ReadLine()) != "Worm Ipsum")
            {
                if (regex.IsMatch(input))
                {
                    var words = input
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    List<string> printResult = new List<string>();

                    printResult = CheckAndReplace(words);

                    Console.WriteLine($"{string.Join(" ", printResult)}");
                }
            }
        }

        static List<string> CheckAndReplace(List<string> words)
        {
            var sb = new StringBuilder();
            int index = 0;
            for (var i = 0; i < words.Count; i++)
            {
                var word = words[i];

                var letter = MostOccurringCharInString(word);
                if (letter != '!')
                {
                    foreach (var l in word)
                    {
                        if (l == ',' || l == '\'' || l == '"' || l == '.')
                        {
                            sb.Append(l);
                        }
                        else
                        {
                            sb.Append(letter);
                        }
                        
                    }
                    index = words.IndexOf(word);
                    words.RemoveAt(index);
                    words.Insert(index, sb.ToString());
                    sb = new StringBuilder();
                }
            }
            return words;
        }

        static char MostOccurringCharInString(string charString)
        {
            int mostOccurrence = -1;
            char mostOccurringChar = ' ';
            foreach (char currentChar in charString)
            {
                int foundCharOccreence = 0;
                foreach (char charToBeMatch in charString)
                {
                    if (currentChar == charToBeMatch)
                    {
                        foundCharOccreence++;
                    }
                }
                if (mostOccurrence < foundCharOccreence)
                {
                    mostOccurrence = foundCharOccreence;
                    mostOccurringChar = currentChar;
                }
            }
            if (mostOccurrence > 1)
            {
                return mostOccurringChar;
            }
            else
            {
                return mostOccurringChar = '!';
            }
        }
    }
}
