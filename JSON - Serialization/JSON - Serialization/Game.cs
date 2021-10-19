using System;
using System.Collections.Generic;
using System.Text;

namespace JSON___Serialization
{
    public class Game
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Date { get; set; }
        public string Summary { get; set; }
        public string MetaScore { get; set; }
        public string UserReview { get; set; }

        public Game()
        {
            Name = string.Empty;
            Platform = string.Empty;
            Date = string.Empty;
            Summary = string.Empty;
            MetaScore = string.Empty;
            UserReview = string.Empty;
        }

        public Game(string line)
        {
            string[] pieces = line.Split(',');
            Name = pieces[0];
            Platform = pieces[1];
            Date = pieces[2];
            Summary = pieces[3];
            MetaScore = pieces[4];
            UserReview = pieces[5];
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
