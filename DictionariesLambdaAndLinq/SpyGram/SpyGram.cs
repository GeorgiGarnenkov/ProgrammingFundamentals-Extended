using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SpyGram
{
    public class SpyGram
    {
        public static void Main()
        {
            var privateKey = Console.ReadLine();
            
            var pattern = @"^TO: [A-Z]+; MESSAGE: .+;$";
            Regex regex = new Regex(pattern);

            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            string message;
            while ((message = Console.ReadLine()) != "END")
            {
                if (message != null && regex.IsMatch(message))
                {
                    var commandArgs = message
                        .Split(new[] {"TO: ", " ", ";", "MESSAGE: "}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var name = commandArgs[0];
                    var encryption = EncryptingMessage(message, privateKey);

                    if (!result.ContainsKey(name))
                    {
                        result.Add(name, new List<string>());
                        result[name].Add(encryption);
                    }
                    else
                    {
                        result[name].Add(encryption);
                    }
                    
                }
            }

            foreach (var kvp in result.OrderBy(a => a.Key))
            {
                foreach (var i in kvp.Value)
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        static string EncryptingMessage(string message, string privateKey)
        {
            StringBuilder nums = new StringBuilder(message.Length);
            for (int i = 0; i < privateKey.Length; i++)
            {
                nums.Append(privateKey[i]);
                if (nums.Length == message.Length)
                {
                    break;
                }
                if (i == privateKey.Length - 1)
                {
                    i = -1;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                int letter = message[i];

                var privateNum = int.Parse(nums[i].ToString());
                var newLetter = letter + privateNum;

                char letterSb = (char)newLetter;

                sb.Append(letterSb);
            }


            return sb.ToString();
        }
    }
}
