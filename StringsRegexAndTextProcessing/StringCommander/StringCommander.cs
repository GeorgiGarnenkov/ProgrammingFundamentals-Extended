namespace StringCommander
{
    using System;
    using System.Linq;

    public class StringCommander
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            string commandinput;
            while ((commandinput = Console.ReadLine()) != "end")
            {
                var commandArgs = commandinput
                    .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = commandArgs[0];
                if (command == "Left")
                {
                        var count = int.Parse(commandArgs[1]);

                        input = MoveLeft(input, count);
                }
                else if (command == "Right")
                {
                        var count = int.Parse(commandArgs[1]);

                        input = MoveRight(input, count);
                }
                else if (command == "Insert")
                {
                    var index = int.Parse(commandArgs[1]);
                    var strings = commandArgs[2];
                    if (index >= 0)
                    {
                        input = input.Insert(index, strings);
                    }
                }
                else if (command == "Delete")
                {
                    var startIndex = int.Parse(commandArgs[1]);
                    var endIndex = int.Parse(commandArgs[2]);

                    if (startIndex >= 0)
                    {
                        input = input.Remove(startIndex, endIndex + 1);
                    }
                }
            }
            Console.WriteLine(input);
        }

        static string MoveRight(string inputStr, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var last = inputStr[inputStr.Length - 1];
                inputStr = inputStr.Remove(inputStr.Length - 1, 1);
                inputStr = inputStr.Insert(0, last.ToString());
            }
            return inputStr;
        }

        static string MoveLeft(string inputStr, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var first = inputStr[0];
                inputStr = inputStr.Remove(0, 1);
                inputStr = string.Join("", inputStr, first);
            }
            return inputStr;
        }
    }
}
