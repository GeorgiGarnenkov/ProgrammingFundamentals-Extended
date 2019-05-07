namespace DecodeRadioFrequencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DecodeRadioFrequencies
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> leftNums = new List<int>();
            List<int> rightNums = new List<int>();

            AddNumbersToLists(numbers, leftNums, rightNums);

            rightNums.Reverse();

            PrintOutput(leftNums, rightNums);
        }

        private static void PrintOutput(List<int> leftNums, List<int> rightNums)
        {
            for (int i = 0; i < leftNums.Count; i++)
            {
                string numToLetter = char.ConvertFromUtf32(leftNums[i]);
                Console.Write(numToLetter);
            }
            for (int i = 0; i < rightNums.Count; i++)
            {
                string numToLetter = char.ConvertFromUtf32(rightNums[i]);
                Console.Write(numToLetter);
            }
        }

        private static void AddNumbersToLists(int[] numbers, List<int> leftNums, List<int> rightNums)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var num = numbers[i];
                if (num != 0 && i % 2 == 0)
                {
                    leftNums.Add(num);
                }
                else if (num != 0 && i % 2 != 0)
                {
                    rightNums.Add(num);
                }
            }
        }
    }
}
