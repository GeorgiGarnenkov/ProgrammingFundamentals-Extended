namespace AnonymousThreat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnonymousThreat
    {
        public static void Main()
        {
            var arrayStrings = Console.ReadLine()
                .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "3:1")
            {
                var commandArgs = input
                    .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = commandArgs[0];

                if (command == "merge")
                {
                    var startIndex = int.Parse(commandArgs[1]);
                    var endIndex = int.Parse(commandArgs[2]);

                    arrayStrings = CommandMerge(arrayStrings, startIndex, endIndex);
                }
                else if (command == "divide")
                {
                    var index = int.Parse(commandArgs[1]);
                    var partition = int.Parse(commandArgs[2]);

                    arrayStrings = CommandDivide(arrayStrings, index, partition);
                }
            }
            Console.WriteLine(string.Join(" ", arrayStrings));
        }

        static List<string> CommandMerge(List<string> arrayStrings, int startIndex, int endIndex)
        {
            startIndex = ChangeIndex(startIndex, arrayStrings.Count);
            endIndex = ChangeIndex(endIndex, arrayStrings.Count);

            List<string> newList = new List<string>();

            if (startIndex > 0)
            {
                for (int i = 0; i < startIndex; i++)
                {
                    newList.Add(arrayStrings[i]);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                sb.Append(arrayStrings[i]);
            }

            newList.Add(sb.ToString());
            for (int i = endIndex + 1; i < arrayStrings.Count; i++)
            {
                newList.Add(arrayStrings[i]);
            }

            return newList;
        }

        static int ChangeIndex(int index, int maxLength)
        {
            if (index < 0)
            {
                index = 0;
            }

            if (index >= maxLength)
            {
                index = maxLength - 1;
            }

            return index;
        }

        static List<string> CommandDivide(List<string> arrayStrings, int index, int partition)
        {
            string element = arrayStrings[index];

            int partitionLength = element.Length / partition;

            List<string> dividedPartitions = new List<string>();

            for (int i = 0; i < partition; i++)
            {
                if (i == partition - 1)
                {
                    dividedPartitions.Add(element.Substring(i * partitionLength));
                }
                else
                {
                    dividedPartitions.Add(element.Substring(i * partitionLength, partitionLength));
                }
            }

            arrayStrings.RemoveAt(index);
            arrayStrings.InsertRange(index, dividedPartitions);

            return arrayStrings;
        }
    }
}
