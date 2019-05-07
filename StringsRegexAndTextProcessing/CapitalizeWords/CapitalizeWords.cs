namespace CapitalizeWords
{
    using System;
    using System.Linq;
    using System.Text;

    public class CapitalizeWords
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != null)
                {
                    var array = input
                        .Split(new [] {'.', ' ', '!', '?', ',', ':', ';', '-', '/', '_'}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    for (var i = 0; i < array.Length; i++)
                    {
                        var temp = array[i].ToCharArray().ToArray();
                        var sb = new StringBuilder();
                        for (var j = 0; j < temp.Length; j++)
                        {

                            if (j != 0)
                            {
                                temp[j] = char.ToLower(temp[j]);
                                sb.Append(temp[j]);
                            }
                            else
                            {
                                temp[j] = char.ToUpper(temp[j]);
                                sb.Append(temp[j]);
                            }
                        }
                        array[i] = sb.ToString();
                    }
                    Console.WriteLine(string.Join(", ", array));
                }
            }
        }
    }
}
