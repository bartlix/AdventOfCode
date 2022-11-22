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
            //var input = File.ReadAllText("Input.txt");
            var input = File.ReadAllLines("Sample.txt");

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

            var list = GetAllCombinations(persons);

            var result = list.Select(x => new { x, sum = 0 }).ToDictionary(x => x.x, x => x.sum);

            foreach (var r in result)
            {
                var x = r.Key.Split(',');

                var sum = 0;

                for (var i = 0; i < x.Length - 1; i++)
                {
                    if (elements.ContainsKey((x[i], x[i + 1])))
                    {
                        sum += elements[(x[i], x[i + 1])];
                    }
                    else if (elements.ContainsKey((x[i + 1], x[i])))
                    {
                        sum += elements[(x[i + 1], x[i])];
                    }
                }

                result[r.Key] = sum;
            }

            //Console.WriteLine(input);
            //Clipboard.SetText(input);
            
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