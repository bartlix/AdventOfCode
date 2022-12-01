using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using Day17;

namespace Day17
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var playground = new Dictionary<(int y, int x), bool>();


            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    playground.Add((y, x), input[y][x] == '#');
                }
            }

            DisplyPlayGround(playground);

            for (var count = 0; count < 100; count++)
            {
                var nextGround = new Dictionary<(int y, int x), bool>();

                foreach (var item in playground)
                {
                    var neighbors = new List<bool>();
                    var x = item.Key.x;
                    var y = item.Key.y;

                    if (playground.ContainsKey((y - 1, x - 1)))
                    {
                        neighbors.Add(playground[(y - 1, x - 1)]);
                    }

                    if (playground.ContainsKey((y - 1, x)))
                    {
                        neighbors.Add(playground[(y - 1, x)]);
                    }

                    if (playground.ContainsKey((y - 1, x + 1)))
                    {
                        neighbors.Add(playground[(y - 1, x + 1)]);
                    }

                    if (playground.ContainsKey((y, x - 1)))
                    {
                        neighbors.Add(playground[(y, x - 1)]);
                    }

                    if (playground.ContainsKey((y, x + 1)))
                    {
                        neighbors.Add(playground[(y, x + 1)]);
                    }

                    if (playground.ContainsKey((y + 1, x - 1)))
                    {
                        neighbors.Add(playground[(y + 1, x - 1)]);
                    }

                    if (playground.ContainsKey((y + 1, x)))
                    {
                        neighbors.Add(playground[(y + 1, x)]);
                    }

                    if (playground.ContainsKey((y + 1, x + 1)))
                    {
                        neighbors.Add(playground[(y + 1, x + 1)]);
                    }

                    if (item.Value && (neighbors.Count(x => x) == 2 || neighbors.Count(x => x) == 3))
                    {
                        nextGround.Add((y, x), true);
                    }
                    else if (!item.Value && neighbors.Count(x => x) == 3)
                    {
                        nextGround.Add((y, x), true);
                    }
                    else
                    {
                        nextGround.Add((y, x), false);
                    }
                }

                DisplyPlayGround(nextGround);

                playground = nextGround;
            }

            var result = playground.Count(x => x.Value);

            Console.WriteLine(result);
            Clipboard.SetText(result.ToString());
            Console.ReadKey();
        }

        private static void DisplyPlayGround(Dictionary<(int y, int x), bool> items)
        {
            var maxY = items.Max(x => x.Key.y);
            var maxX = items.Max(x => x.Key.x);

            StringBuilder sb = new StringBuilder();

            for (var y = 0; y <= maxY; y++)
            {
                for (var x = 0; x <= maxX; x++)
                {
                    sb.Append(items[(y,x)] ? "#" : ".");
                }

                Console.WriteLine(sb.ToString());
                sb.Clear();
            }

            Console.WriteLine("--------------------------------------");
        }
    }
}