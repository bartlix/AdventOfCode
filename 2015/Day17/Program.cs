using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    var all = GetAllCombinations(input.ToList());
        //    var count = 0;

        //    foreach (var i in all)
        //    {
        //        var parts = i.Split(',');

        //        var sum = parts.Select(x => int.Parse(x)).Sum();

        //        if (sum == 150)
        //        {
        //            Console.WriteLine(i);
        //            count++;
        //        }

        //    }

        //    Console.WriteLine("--------------------------------------");

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());
        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var all = GetAllCombinations(input.ToList());
            var count = 0;

            var result = new List<(string key , int value)>();

            foreach (var i in all)
            {
                var parts = i.Split(',');

                var sum = parts.Select(x => int.Parse(x)).Sum();

                if (sum == 150)
                {
                    result.Add((i, parts.Length));
                    Console.WriteLine(i);
                }

            }

            var min = result.Min(x => x.value);

            count = result.Count(x => x.value == min);

            Console.WriteLine("--------------------------------------");

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());
            Console.ReadKey();
        }

        private static List<string> GetAllCombinations(List<string> list)
        {
            var anz = Enumerable.Range(1, list.Count);
            var result = new List<string>();

            foreach(var i in anz)
            {
                var x = list.ToArray().CombinationsWithoutRepetition(i).ToList();

                result.AddRange(x.Select(y => string.Join(',', y)).ToList());
            }

            return result;
        }
    }
}