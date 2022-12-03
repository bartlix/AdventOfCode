using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace Day3
{
    class Programm
    {
        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    var sum = 0;

        //    foreach (var line in input)
        //    {
        //        var part1 = line.Substring(0, line.Length/2);
        //        var part2 = line.Substring(line.Length/2);

        //        foreach(var c in part1)
        //        {
        //            if (part2.Contains(c))
        //            {
        //                if (c <= 'Z')
        //                {
        //                    sum += (c - 'A' + 27);
        //                    break;
        //                }
        //                else
        //                {
        //                    sum += (c - 'a' + 1);
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    Console.WriteLine("--------------------------------------");

        //    var count = sum;

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());
        //    Console.ReadKey();
        //}

        //Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var sum = 0;

            for (var i = 0; i < input.Length - 2; i+=3)
            {
                foreach (var c in input[i])
                {
                    if (input[i+1].Contains(c) && input[i + 2].Contains(c))
                    {
                        if (c <= 'Z')
                        {
                            sum += (c - 'A' + 27);
                            break;
                        }
                        else
                        {
                            sum += (c - 'a' + 1);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("--------------------------------------");

            var count = sum;

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());
            Console.ReadKey();
        }
    }
}