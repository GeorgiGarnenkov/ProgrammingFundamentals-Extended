namespace ArrayHistogram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ArrayHistogram
    {
        public static void Main()
        {
            string[] array = Console.ReadLine()
                .Split()
                .ToArray();

            List<string> words = new List<string>();

            List<int> wordsCount = new List<int>();

            AddWordsAndCountsToList(array, words, wordsCount);

            OrderTheArrayDescending(array, wordsCount, words);

            PrintArrayOfWords(array, words, wordsCount);
        }

        private static void OrderTheArrayDescending(string[] array, List<int> wordsCount, List<string> words)
        {
            for (int i = 0; i < wordsCount.Count - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (wordsCount[j] > wordsCount[j - 1])
                    {
                        var tempCount = wordsCount[j];
                        wordsCount[j] = wordsCount[j - 1];
                        wordsCount[j - 1] = tempCount;

                        var tempWords = words[j];
                        words[j] = words[j - 1];
                        words[j - 1] = tempWords;
                    }
                    j--;
                }
            }
        }

        private static void AddWordsAndCountsToList(string[] array, List<string> words, List<int> wordsCount)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var word = array[i];
                if (words.Contains(word))
                {
                    int wordIndex = words.IndexOf(word);
                    wordsCount[wordIndex]++;
                }
                else
                {
                    words.Add(word);
                    wordsCount.Add(1);
                }
            }
        }

        private static void PrintArrayOfWords(string[] array, List<string> words, List<int> wordsCount)
        {
            for (int i = 0; i < words.Count; i++)
            {
                double percent = (wordsCount[i] * 100.0) / array.Length;
                var word = words[i];
                var wordCount = wordsCount[i];

                Console.WriteLine($"{word} -> {wordCount} times ({percent:f2}%)");
            }
        }
    }
}
