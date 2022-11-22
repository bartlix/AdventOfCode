using System.Collections;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day13
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var elements = new Dictionary<(string a, string b), int> ();

            List<string> persons = new List<string>();

            foreach(var row in input)
            {
                var part = row.Replace("would ", "").Replace("happiness units by sitting next to ", "").Replace(".", "");

                var s = part.Split(' ');

                var value = int.Parse(s[2]);

                if (s[1] == "lose")
                {
                    value = value * -1;
                }

                persons.Add(s[0]);
                persons.Add(s[3]);

                elements.Add((s[0], s[3]), value);
            }

            persons = persons.Distinct().ToList();

            //Part 2
            foreach ( var p in persons)
            {
                elements.Add(("Thomas", p), 0);
                elements.Add((p, "Thomas"), 0);
            }
            
            persons.Add("Thomas");

            // Part 2 - Ende

            var list = GetAllCombinations(persons);

            var result = list.Select(x => new { x, sum = 0 }).ToDictionary(x => x.x, x => x.sum);

            foreach (var r in result)
            {
                var x = r.Key.Split(',');

                var sum = 0;

                for (var i = 0; i < x.Length; i++)
                {
                    var next = (i + 1) > x.Length -1  ? 0 : i+1;

                    var val = elements[(x[i], x[next])];
                    //Console.WriteLine($"{x[i]} & {x[next]}:{val}");
                    sum += val;

                    val = elements[(x[next], x[i])];
                    //Console.WriteLine($"{x[next]} & {x[i]}:{val}");
                    sum += val;
                }

                result[r.Key] = sum;
            }

            var max = result.Max(x => x.Value);

            Console.WriteLine(max);
            Clipboard.SetText(max.ToString());
            
            Console.ReadKey();
        }

        public static List<string> GetAllCombinations(List<string> items)
        {
            var result = new List<string>();

            for (var i = 0; i < items.Count; i++)
            {
                var sb = new StringBuilder();

                if (items.Count > 1)
                {
                    var sss = GetAllCombinations(items.Where(x => x != items[i]).ToList());

                    foreach (var s in sss)
                    {
                        sb.Append(items[i]);
                        sb.Append(',');
                        sb.Append(s);
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                else
                {
                    sb.Append(items[i]);
                    result.Add(sb.ToString());
                }
            }

            return result;
        }
    }
}