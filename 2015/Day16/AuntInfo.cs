using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class AuntInfo
    {
        public AuntInfo()
        {
        }

        public AuntInfo(string data)
        {
            Parse(data);
        }

        public int Id { get; set; }
        
        public int? Children { get; set; }
        
        public int? Cats { get; set; }
        
        public int? Samoyeds { get; set; }
        
        public int? Pomeranians { get; set; }
        
        public int? Akitas { get; set; }
        
        public int? Vizslas { get; set; }
        
        public int? Goldfish { get; set; }
        
        public int? Trees { get; set; }
        
        public int? Cars { get; set; }
        
        public int? Perfumes { get; set; }

        public int GetScore(AuntInfo info)
        {
            var score = 0;

            if (Children.HasValue && info.Children == Children.Value)
            {
                score += 1;
            }

            if (Cats.HasValue && info.Cats == Cats.Value)
            {
                score += 1;
            }

            if (Samoyeds.HasValue && info.Samoyeds == Samoyeds.Value)
            {
                score += 1;
            }

            if (Pomeranians.HasValue && info.Pomeranians == Pomeranians.Value)
            {
                score += 1;
            }

            if (Goldfish.HasValue && info.Goldfish == Goldfish.Value)
            {
                score += 1;
            }

            if (Vizslas.HasValue && info.Vizslas == Vizslas.Value)
            {
                score += 1;
            }

            if (Trees.HasValue && info.Trees == Trees.Value)
            {
                score += 1;
            }

            if (Cars.HasValue && info.Cars == Cars.Value)
            {
                score += 1;
            }

            if (Perfumes.HasValue && info.Perfumes == Perfumes.Value)
            {
                score += 1;
            }

            return score;
        }

        private void Parse(string data)
        {
            var part = data.Split(':');

            var name = part[0].Split(' ');
            Id = int.Parse(name[1]);

            part = data.Replace($"{part[0]}:", "").Replace(" ", "").Split(',');

            foreach (var item in part)
            {
                var i = item.Split(":");

                switch (i[0])
                {
                    case "children":
                        Children = int.Parse(i[1]);
                        break;
                    case "cats":
                        Cats = int.Parse(i[1]);
                        break;
                    case "samoyeds":
                        Samoyeds = int.Parse(i[1]);
                        break;
                    case "pomeranians":
                        Pomeranians = int.Parse(i[1]);
                        break;
                    case "akitas":
                        Akitas = int.Parse(i[1]);
                        break;
                    case "vizslas":
                        Vizslas = int.Parse(i[1]);
                        break;
                    case "goldfish":
                        Goldfish = int.Parse(i[1]);
                        break;
                    case "trees":
                        Trees = int.Parse(i[1]);
                        break;
                    case "cars":
                        Cars = int.Parse(i[1]);
                        break;
                    case "perfumes":
                        Perfumes = int.Parse(i[1]);
                        break;
                }
            }
            //"Sue 1: goldfish: 6, trees: 9, akitas: 0"
        }
    }
}
