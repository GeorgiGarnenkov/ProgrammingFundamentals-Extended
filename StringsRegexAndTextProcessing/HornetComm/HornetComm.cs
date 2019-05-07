namespace HornetComm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;


    public class HornetComm
    {
        public static void Main()
        {
            string messagePattern = @"^[0-9]+ <-> [A-Za-z0-9]+$";
            string broadcastPattern = @"^[\D]+ <-> [A-Za-z0-9]+$";

            string input;
            List<string> message = new List<string>();
            List<string> broadcast = new List<string>();
            while ((input = Console.ReadLine()) != "Hornet is Green")
            {
                var command = input;

                if (Regex.IsMatch(command, messagePattern))
                {
                    message.Add(command);
                }
                else if (Regex.IsMatch(command, broadcastPattern))
                {
                    broadcast.Add(command);
                }
            }
            var messageResult = new List<string>();
            if (message.Count > 0)
            {
                foreach (var m in message)
                {
                    var commandArgs = m
                        .Split(new[] {" <-> "}, 
                        StringSplitOptions.RemoveEmptyEntries);
                    var first = 
                        string.Join("",commandArgs[0].ToCharArray().Reverse().ToArray());
                    var second = commandArgs[1];

                    messageResult.Add(first);
                    messageResult.Add(second);
                }
            }
            var broadcastResult = new List<string>();
            if (broadcast.Count > 0)
            {
                foreach (var b in broadcast)
                {
                    var commandArgs = b
                        .Split(new[] { " <-> " },
                            StringSplitOptions.RemoveEmptyEntries);

                    var first = commandArgs[0];
                    var second = commandArgs[1].ToCharArray().ToArray();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < second.Length; i++)
                    {
                        var letter = second[i];
                        var newLetter = "";
                        if (char.IsLetter(letter))
                        {
                            if (char.IsLower(letter))
                            {
                                newLetter = letter.ToString().ToUpper();
                                sb.Append(newLetter);
                            }
                            else if (char.IsUpper(letter))
                            {
                                newLetter = letter.ToString().ToLower();
                                sb.Append(newLetter);
                            }
                        }
                        else
                        {
                            sb.Append(letter);
                        }
                    }
                    
                    
                    broadcastResult.Add(sb.ToString());
                    broadcastResult.Add(first);
                }
            }
            Console.WriteLine("Broadcasts:");
            if (broadcastResult.Count > 0)
            {
                for (int i = 0; i < broadcastResult.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write($"{broadcastResult[i]} -> ");
                    }
                    else if (i % 2 != 0)
                    {
                        Console.WriteLine(broadcastResult[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (messageResult.Count > 0)
            {
                for (int i = 0; i < messageResult.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write($"{messageResult[i]} -> ");
                    }
                    else if (i % 2 != 0)
                    {
                        Console.WriteLine(messageResult[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            
        }
    }
}
