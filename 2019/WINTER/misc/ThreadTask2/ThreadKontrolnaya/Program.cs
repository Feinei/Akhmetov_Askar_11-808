using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ThreadKontrolnaya
{
    // Задача 2
    class Program
    {
        static readonly string commentsFile = @"C:\Users\Аскар\source\repos\ThreadKontrolnaya\comments.txt";
        static readonly string commentsString = File.ReadAllText(commentsFile);
        static Queue<Comment> comments = new Queue<Comment>();

        static void Main(string[] args)
        {
            var deserialize = new Action(Deserialize).BeginInvoke(null, null);
            while (!deserialize.IsCompleted || comments.Count != 0)
            {
                if (comments.Count != 0)
                {
                    lock (comments)
                    {
                        var comment = comments.Dequeue();
                        if (int.Parse(comment.Id) % 2 == 0)
                            Console.WriteLine(GetLetterCount(comment.Body));
                    }
                }
            }

            Console.ReadKey();
        }

        static void Deserialize()
        {
            foreach (var e in JsonConvert.DeserializeObject<Comment[]>(commentsString))
                lock (comments)
                {
                    comments.Enqueue(e);
                    Console.WriteLine("Deserialised");
                }
        }

        static int GetLetterCount(string comment)
        {
            return comment
             .Where(ch => char.IsLetter(ch))
             .Count();
        }
    }

    class Comment
    {
        public string PostId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
