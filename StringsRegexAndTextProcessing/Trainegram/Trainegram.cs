namespace Trainegram
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;


    public class Trainegram
    {
        public static void Main()
        {
            string patternTrain = @"^(\<\[[^A-Za-z0-9\n]*\]\.)(\.\[[A-Za-z0-9]*\]\.)*$";

            List<string> trains = new List<string>();
            string input;
            while ((input = Console.ReadLine())!= "Traincode!")
            {
                string train = input;

                if (Regex.IsMatch(train, patternTrain))
                {
                    trains.Add(train);
                }
            }
            foreach (var train in trains)
            {
                Console.WriteLine(train);
            }
        }
    }
}
