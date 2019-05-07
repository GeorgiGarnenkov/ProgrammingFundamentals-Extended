namespace AnonymousDownsite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;
    
    public class AnonymousDownsite
    {
        public static void Main()
        {
            var numberOfSites = int.Parse(Console.ReadLine());

            BigInteger securityKey = BigInteger.Parse(Console.ReadLine());

            decimal siteLoss = 0;
            decimal totalLoss = 0;
            List<string> sites = new List<string>();
            for (int i = 0; i < numberOfSites; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var siteVisits = decimal.Parse(commandArgs[1]);
                var siteCommercialPricePerVisit = decimal.Parse(commandArgs[2]);

                siteLoss = siteVisits * siteCommercialPricePerVisit;
                totalLoss += siteLoss;
                sites.Add(commandArgs[0]);
            }

            for (int i = 0; i < sites.Count; i++)
            {
                Console.WriteLine(sites[i]);
            }

            var securityToken = BigInteger.Pow(securityKey, numberOfSites);

            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}
