using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoliTheCoder
{
    public class Event
    {
        public string Name { get; set; }

        public List<string> Participants { get; set; }

        public Event(string name, List<string> participants)
        {
            name = Name;
            participants = Participants;
        }

    }

    public class RoliTheCoder
    {
        public static void Main()
        {
            Dictionary<int, Event> dictEvents = new Dictionary<int, Event>();

            Regex regex = new Regex(@"^(?<id>\d+)\s*#(?<eventName>\w+)\s*(?<participants>(?:@[a-zA-Z\d'-]+\s*)*)$");

            string input;

            while ((input = Console.ReadLine()) != "Time for Code")
            {
                Match eventMatch = regex.Match(input);
                if (eventMatch.Success == false)
                {
                    continue;
                }

                int id = int.Parse(eventMatch.Groups["id"].Value);
                string eventName = eventMatch.Groups["eventName"].Value;
                List<string> participants = eventMatch.Groups["participants"].Value
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (!dictEvents.ContainsKey(id))
                {
                    dictEvents.Add(id, new Event(eventName, participants));
                }
                else if (dictEvents[id].Name == eventName)
                {
                    dictEvents[id].Participants.AddRange(participants);
                    dictEvents[id].Participants = dictEvents[id].Participants.Distinct().ToList();
                }
            }



        }
    }
}
