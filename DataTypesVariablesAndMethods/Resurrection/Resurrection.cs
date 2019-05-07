namespace Resurrection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Phoenix
    {
        public int BodyLength { get; set; }

        public decimal BodyWidth { get; set; }

        public decimal WingWidth { get; set; }
    }

    public class Resurrection
    {
        public static void Main()
        {
            var countPhoenix = int.Parse(Console.ReadLine());

            List<Phoenix> phoenixes = new List<Phoenix>();
            for (int i = 0; i < countPhoenix; i++)
            {
                Phoenix phoenix = new Phoenix();
                var bodyLenght = int.Parse(Console.ReadLine());

                var bodyWidth = decimal.Parse(Console.ReadLine());

                var wingWidth = decimal.Parse(Console.ReadLine());
                phoenix.BodyLength = bodyLenght;
                phoenix.BodyWidth = bodyWidth;
                phoenix.WingWidth = wingWidth;

                phoenixes.Add(phoenix);
            }

            foreach (var p in phoenixes)
            {
                double totalLength = Math.Pow(p.BodyLength, 2);

                decimal totalWidth = p.BodyWidth + (2 * p.WingWidth);

                decimal years = (decimal)totalLength * totalWidth;
                Console.WriteLine($"{years}");
            }
        }
    }
}
