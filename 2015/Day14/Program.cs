using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using Day14;

namespace Day13
{
    class Programm
    {
        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    var deerList = new List<FlightInfo>();

        //    var resultList = new Dictionary<string, int>();


        //    foreach(var line in input)
        //    {   
        //        deerList.Add(new FlightInfo(line));
        //    }

        //    foreach(var deer in deerList)
        //    {
        //        var r = deer.GetDistance(2503);

        //        resultList.Add(deer.Name, r);
        //    }

        //    var re = resultList.Max(x => x.Value);
        //    Console.WriteLine(re);
        //    Clipboard.SetText(re.ToString());
        //    Console.ReadKey();
        //}

        //Part 2 
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var deerList = new List<FlightInfo>();

            foreach (var line in input)
            {
                deerList.Add(new FlightInfo(line));
            }

            //var resultList = deerList.Select(x => x.Name).ToDictionary(x => x, x => 0);

            for (var i = 1; i <= 2503; i++)
            {
                foreach(var deer in deerList)
                {
                    deer.SetDistance(i);
                }

                var maxDist = deerList.Max(x => x.Distance);

                deerList.Where(x => x.Distance == maxDist).ToList().ForEach(x => x.Points += 1);
            }

            var re = deerList.Max(x => x.Points);
            Console.WriteLine(re);
            Clipboard.SetText(re.ToString());
            Console.ReadKey();
        }
    }
}