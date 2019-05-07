namespace SocialMediaPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class SocialMediaPosts
    {
        public static void Main()
        {
            string input;
            Dictionary<string, int> postsLikes =
                new Dictionary<string, int>();

            Dictionary<string, int> postsDislike =
                new Dictionary<string, int>();

            Dictionary<string, Dictionary<string, List<string>>> comments =
                new Dictionary<string, Dictionary<string, List<string>>>();


            while ((input = Console.ReadLine()) != "drop the media")
            {
                if (input != null)
                {
                    var commandArgs = input
                        .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var command = commandArgs[0];

                    if (command == "post")
                    {
                        var name = commandArgs[1];
                        if (!postsLikes.ContainsKey(name))
                        {
                            postsLikes.Add(name, 0);
                        }
                        if (!postsDislike.ContainsKey(name))
                        {
                            postsDislike.Add(name, 0);
                        }
                        if (!comments.ContainsKey(name))
                        {
                            comments.Add(name, new Dictionary<string, List<string>>());
                        }
                    }
                    else if (command == "like")
                    {
                        var name = commandArgs[1];
                        postsLikes[name]++;
                    }
                    else if (command == "dislike")
                    {
                        var name = commandArgs[1];
                        postsDislike[name]++;
                    }
                    else if (command == "comment")
                    {
                        var name = commandArgs[1];
                        var commentator = commandArgs[2];
                        var comment = string.Join(" ", commandArgs.Skip(3));

                        if (comments.ContainsKey(name))
                        {
                            if (!comments[name].ContainsKey(commentator))
                            {
                                comments[name].Add(commentator, new List<string>());
                                comments[name][commentator].Add(comment);
                            }
                            else
                            {
                                comments[name][commentator].Add(comment);
                            }
                        }
                    }
                }
            }
            foreach (var like in postsLikes)
            {
                Console.WriteLine($"Post: {like.Key} | Likes: {like.Value} | Dislikes: {postsDislike[like.Key]}");
                Console.WriteLine("Comments:");
                if (comments[like.Key].Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    foreach (var c in comments[like.Key])
                    {
                        foreach (var values in c.Value)
                        {
                            Console.WriteLine($"*  {c.Key}: {values}");
                        }
                    }
                }
            }
        }
    }
}
