using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day1
{
    class Programm
    {
        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");
        //    var count = 0;
        //    var sum = 0;

        //    var result = new List<int>();

        //    foreach(var line in input)
        //    {
        //        if (string.IsNullOrEmpty(line))
        //        {
        //            result.Add(sum);
        //            sum = 0;
        //        }
        //        else
        //        {
        //            sum += int.Parse(line);
        //        }
        //    }

        //    if(sum > 0)
        //    {
        //        result.Add(sum);
        //    }

        //    Console.WriteLine("--------------------------------------");

        //    count = result.Max();

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());
        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");
            var count = 0;
            var sum = 0;

            var result = new List<int>();

            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    result.Add(sum);
                    sum = 0;
                }
                else
                {
                    sum += int.Parse(line);
                }
            }

            if (sum > 0)
            {
                result.Add(sum);
            }

            Console.WriteLine("--------------------------------------");

            count = result.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());
            Console.ReadKey();
        }
    }
}