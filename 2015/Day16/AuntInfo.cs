using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class AuntInfo
    {
        public AuntInfo(string data)
        {
            Parse(data);
        }

        public int Id { get; private set; }
        public int? Children { get; private set; }
        public int? Cats { get; private set; }
        public int? Samoyeds { get; private set; }
        public int? Pomeranians { get; private set; }
        public int? Akitas { get; private set; }
        public int? Vizslas { get; private set; }
        public int? Goldfish { get; private set; }
        public int? Trees { get; private set; }
        public int? Cars { get; private set; }
        public int? Perfumes { get; private set; }

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
