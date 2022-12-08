using System.ComponentModel.Design;
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
        //static void Main(string[] args)
        //{
        //    var content = File.ReadAllLines("Input.txt");
        //    //var content = File.ReadAllLines("Sample.txt");

        //    var trees = new Dictionary<(int y, int x), int>();

        //    for (int y = 0; y < content.Length; y++)
        //    {
        //        for (int x = 0; x < content[y].Length; x++)
        //        {
        //            trees.Add((y, x), int.Parse(content[y][x].ToString()));
        //        }
        //    }

        //    var count = content.Length * 2;
        //    count += (content[0].Length - 2) * 2;

        //    var maxX = trees.Count(x => x.Key.x == 0);
        //    var maxY = trees.Count(x => x.Key.y == 0);

        //    for (int y = 1; y < maxY - 1; y++)
        //    {
        //        for (int x = 1; x < maxX - 1; x++)
        //        {
        //            var t = trees[(y, x)];

        //            if (trees.Where(p => p.Key.y == y && p.Key.x < x).All(x => x.Value < t))
        //            {
        //                count++;
        //                continue;
        //            }
        //            else if (trees.Where(p => p.Key.y < y && p.Key.x == x).All(x => x.Value < t))
        //            {
        //                count++;
        //                continue;
        //            }
        //            else if (trees.Where(p => p.Key.y == y && p.Key.x > x).All(x => x.Value < t))
        //            {
        //                count++;
        //                continue;
        //            }
        //            else if (trees.Where(p => p.Key.y > y && p.Key.x == x).All(x => x.Value < t))
        //            {
        //                count++;
        //                continue;
        //            }
        //        }
        //    }

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());

        //    Console.ReadKey();
        //}

        // Part 2
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

            var scores = new List<int>();

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    var singleScore = new List<int>();
                    var t = trees[(y, x)];

                    var left = trees.Where(p => p.Key.y == y && p.Key.x < x);
                    if (left.Any(x => x.Value >= t))
                    {
                        var ssss = left.OrderByDescending(x => x.Key.x).First(x => x.Value >= t);
                        singleScore.Add(Math.Abs(ssss.Key.x - x));
                    }
                    else
                    {
                        singleScore.Add(left.Count());
                    }

                    var top = trees.Where(p => p.Key.y < y && p.Key.x == x);
                    if (top.Any(x => x.Value >= t))
                    {
                        var ssss = top.OrderByDescending(x => x.Key.y).First(x => x.Value >= t);
                        singleScore.Add(Math.Abs(ssss.Key.y - y));
                    }
                    else
                    {
                        singleScore.Add(top.Count());
                    }

                    var right = trees.Where(p => p.Key.y == y && p.Key.x > x);
                    if (right.Any(x => x.Value >= t))
                    {
                        var ssss = right.OrderByDescending(x => x.Key.x).First(x => x.Value >= t);
                        singleScore.Add(Math.Abs(ssss.Key.x - x));
                    }
                    else
                    {
                        singleScore.Add(right.Count());
                    }

                    var bottom = trees.Where(p => p.Key.y > y && p.Key.x == x);
                    if (bottom.Any(x => x.Value >= t))
                    {
                        var ssss = bottom.OrderByDescending(x => x.Key.y).First(x => x.Value >= t);
                        singleScore.Add(Math.Abs(ssss.Key.y - y));
                    }
                    else
                    {
                        singleScore.Add(bottom.Count());
                    }

                    scores.Add(singleScore.Aggregate((a, b) => a * b));
                }
            }

            count = scores.Max();

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());

            Console.ReadKey();
        }
    }
}