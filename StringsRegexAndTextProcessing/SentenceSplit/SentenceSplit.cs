namespace SentenceSplit
{
    using System;
    using System.Linq;


    public class SentenceSplit
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var delimiter = Console.ReadLine();
            var array = input
                .Split(new string[] {delimiter},StringSplitOptions.None)
                .ToArray();

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }
    }
}
