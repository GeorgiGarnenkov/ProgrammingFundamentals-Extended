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
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                sb.Append(Encrypt(letter));
            }
            Console.WriteLine(sb.ToString());


        }

        static string Encrypt(char letter)
        {
            StringBuilder sb = new StringBuilder();
            int numFromLetter = letter;

            string firstNum = numFromLetter.ToString().First().ToString();
            string secondNum = numFromLetter.ToString().Last().ToString();

            int firstLetterNum = numFromLetter + int.Parse(secondNum);
            int secondLetterNum = numFromLetter - int.Parse(firstNum);

            string firstLetterToChar = char.ConvertFromUtf32(firstLetterNum);
            string secondLetterToChar = char.ConvertFromUtf32(secondLetterNum);

            sb.Append(firstLetterToChar);
            sb.Append(firstNum);
            sb.Append(secondNum);
            sb.Append(secondLetterToChar);

            return sb.ToString();
        }
    }
}