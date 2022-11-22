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
            //var input = File.ReadAllLines("Input.txt");
            var input = File.ReadAllLines("Sample.txt");

            var ingredients = new List<IngredientsInfo>();

            foreach (var row in input)
            {
                ingredients.Add(new IngredientsInfo(row));
            }

            var dict = new Dictionary<int, int>(Enumerable.Range(0, 100).ToDictionary(x => x, x => 0));


            foreach (var d in dict)
            {
                dict[d.Key] = (ingredients[0].Capacity * d.Key + ingredients[1].Capacity * (100-d.Key))*
                            (ingredients[0].Texture * d.Key + ingredients[1].Texture * (100 - d.Key))*
                            (ingredients[0].Flavor * d.Key + ingredients[1].Flavor * (100 - d.Key))*
                            (ingredients[0].Durability * d.Key + ingredients[1].Durability * (100 - d.Key));
            }

            var re = dict[44];

            Console.WriteLine(re);
            Clipboard.SetText(re.ToString());
            Console.ReadKey();
        }
    }
}