using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day15
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var ingredients = new List<IngredientsInfo>();

            foreach (var row in input)
            {
                ingredients.Add(new IngredientsInfo(row));
            }

            var dict = new Dictionary<(int a, int b, int c, int d), int>();

            for (int a = 1; a < 98; a++)
            {
                for ( int b = 1; b < 98; b++ )
                {
                    for (int c = 1; c < 98; c++)
                    {
                        dict.Add((a, b, c,100 - a - b - c), 0);
                    }
                }
            }

            foreach (var d in dict)
            {
                var capacity = ingredients[0].Capacity * d.Key.a + ingredients[1].Capacity * d.Key.b + ingredients[2].Capacity * d.Key.c + ingredients[3].Capacity * d.Key.d;
                var texture = ingredients[0].Texture * d.Key.a + ingredients[1].Texture * d.Key.b + ingredients[2].Texture * d.Key.c + ingredients[3].Texture * d.Key.d;
                var flavor = ingredients[0].Flavor * d.Key.a + ingredients[1].Flavor * d.Key.b + ingredients[2].Flavor * d.Key.c + ingredients[3].Flavor * d.Key.d;
                var durability = ingredients[0].Durability * d.Key.a + ingredients[1].Durability * d.Key.b + ingredients[2].Durability * d.Key.c + ingredients[3].Durability * d.Key.d;
                
                capacity = capacity < 0 ? 0 : capacity;
                texture = texture < 0 ? 0 : texture;
                flavor = flavor < 0 ? 0 : flavor;
                durability = durability < 0 ? 0 : durability;

                dict[d.Key] = capacity * texture * flavor * durability;
            }


            var re = dict.Max(d => d.Value);
            //var re = dict[44];

            Console.WriteLine(re);
            Clipboard.SetText(re.ToString());
            Console.ReadKey();
        }
    }
}