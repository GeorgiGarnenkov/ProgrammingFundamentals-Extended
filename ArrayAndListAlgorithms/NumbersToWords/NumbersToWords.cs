namespace ArraysExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArraysExercise
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > 999)
                {
                    Console.WriteLine($"too large");
                }
                else if (number < -999)
                {
                    Console.WriteLine($"too small");
                }
                else if (number.ToString().Length < 3 && number.ToString().Length > 3)
                {
                    continue;
                }
                else if (number.ToString().Length == 3 || number.ToString().Length == 4)
                {
                    string result = NumberToWords(Math.Abs(number));
                    if (number < 0)
                    {
                        Console.WriteLine($"minus {result}");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
            }
        }

        public static string NumberToWords(int number)
        {
            string words = "";

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + "-hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                {
                    words += "and ";
                }

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        words += " " + unitsMap[number % 10];
                    }
                }
            }
            return words;
        }
    }
}
