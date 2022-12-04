using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace Day04
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var sum = 0;

            foreach (var line in input)
            {
                var part = line.Split(',');

                var places = part[0].Split("-");
                var a = Enumerable.Range(int.Parse(places[0]), int.Parse(places[1]) - int.Parse(places[0]) + 1).ToArray();

                places = part[1].Split("-");

                var b = Enumerable.Range(int.Parse(places[0]), int.Parse(places[1]) - int.Parse(places[0]) + 1).ToArray();


                if(a.All(x => b.Contains(x)) || b.All(x => a.Contains(x)))
                {
                    sum++;
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