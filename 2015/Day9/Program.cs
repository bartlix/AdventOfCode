using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day9
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var s = new Dictionary<(string src, string dest), int>();
            var targets = new List<string>();

            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            foreach(var line in input) 
            {
                var b = line.Split('=');

                var a = b[0].Trim().Split("to");

                targets.Add(a[0].Trim());
                targets.Add(a[1].Trim());

                s.Add((a[0].Trim(), a[1].Trim()), int.Parse(b[1]));
            }

            targets = targets.Distinct().OrderBy(x => x).ToList();

            var list = GetAllCombinations(targets);

            var result = list.Select(x => new { x, sum = 0 }).ToDictionary(x => x.x, x => x.sum);

            foreach(var r in result)
            {
                var x = r.Key.Split(',');

                var sum = 0;

                for (var i = 0; i < x.Length - 1; i++)
                {
                    if(s.ContainsKey((x[i], x[i+1]))){
                        sum += s[(x[i], x[i+1])];
                    }
                    else if (s.ContainsKey((x[i + 1], x[i])))
                    {
                        sum += s[(x[i + 1], x[i])];
                    }
                }

                result[r.Key] = sum;
            }

            //Part 1
            var rrrrrrrr = result.Min(x => x.Value);

            //Part 2
            rrrrrrrr = result.Max(x => x.Value);

            Console.WriteLine($"Result: {rrrrrrrr}");
            Clipboard.SetText(rrrrrrrr.ToString());

            Console.ReadKey();
        }

        public static List<string> GetAllCombinations(List<string> items)
        {
            var result = new List<string>();

            for (var i = 0;i<items.Count;i++)
            {
                var sb = new StringBuilder();

                if (items.Count > 1)
                {
                    var sss = GetAllCombinations(items.Where(x => x != items[i]).ToList());

                    foreach(var s in sss)
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