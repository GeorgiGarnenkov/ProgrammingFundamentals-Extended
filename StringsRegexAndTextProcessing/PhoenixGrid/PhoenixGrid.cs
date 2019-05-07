namespace PhoenixGrid
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class PhoenixGrid
    {
        public static void Main()
        {
            string input;
            string pattern = @"^([^\s_]{3})(\.[^\s_]{3})*$";

            while ((input = Console.ReadLine()) != "ReadMe")
            {
                var phrase = input;

                MatchCollection matches = Regex.Matches(phrase, pattern);
                if (matches.Count == 0)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    var match = "";
                    foreach (Match m in matches)
                    {
                        match = m.ToString();
                    }
                    var reverseMatch = ReverseString(match);
                    if (match == reverseMatch)
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
            }
        }

        public static string ReverseString(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);

            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            return sb.ToString();
        }

    }
}
