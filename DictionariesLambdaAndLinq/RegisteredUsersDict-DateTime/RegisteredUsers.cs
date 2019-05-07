using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RegisteredUsersDict_DateTime
{
    class RegisteredUsers
    {
        static void Main()
        {
            Dictionary<string, DateTime> users = new Dictionary<string, DateTime>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                var commandArgs = input
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = commandArgs[0];
                var date = DateTime.ParseExact(commandArgs[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                users.Add(name, date);
            }
            if (users.Values.Count < 5)
            {
                foreach (var kvp in users.OrderByDescending(a => a.Value).ThenByDescending(a => a.Key))
                {
                    Console.WriteLine(kvp.Key);
                }
            }
            else
            {
                foreach (var kvp in users.Reverse().OrderBy(a => a.Value).Take(5).OrderByDescending(a => a.Value))
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
