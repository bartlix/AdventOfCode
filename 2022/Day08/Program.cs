using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day08
{
    internal class Programm
    {
        [STAThread]
        // Part 1
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");
            //var content = File.ReadAllLines("Sample.txt");

            var trees = new Dictionary<(int y, int x), int>();

            for (int y = 0; y < content.Length; y++)
            {
                for (int x = 0; x < content[y].Length; x++)
                {
                    trees.Add((y, x), int.Parse(content[y][x].ToString()));
                }
            }

            var count = content.Length * 2;
            count += (content[0].Length - 2) * 2;

            var maxX = trees.Count(x => x.Key.x == 0);
            var maxY = trees.Count(x => x.Key.y == 0);

            for (int y = 1; y < maxY - 1; y++)
            {
                for (int x = 1; x < maxX - 1; x++)
                {
                    var t = trees[(y, x)];

                    if (trees.Where(p => p.Key.y == y && p.Key.x < x).All(x => x.Value < t))
                    {
                        count++;
                        continue;
                    }
                    else if (trees.Where(p => p.Key.y < y && p.Key.x == x).All(x => x.Value < t))
                    {
                        count++;
                        continue;
                    }
                    else if (trees.Where(p => p.Key.y == y && p.Key.x > x).All(x => x.Value < t))
                    {
                        count++;
                        continue;
                    }
                    else if (trees.Where(p => p.Key.y > y && p.Key.x == x).All(x => x.Value < t))
                    {
                        count++;
                        continue;
                    }
                }
            }

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());

            Console.ReadKey();
        }
    }
}