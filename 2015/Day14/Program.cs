using System.Collections;
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
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var deerList = new List<FlightInfo>();

            var resultList = new Dictionary<string, int>();


            foreach(var line in input)
            {   
                deerList.Add(new FlightInfo(line));
            }

            foreach(var deer in deerList)
            {
                var r = deer.GetDistance(2503);

                resultList.Add(deer.Name, r);
            }

            var re = resultList.Max(x => x.Value);
            Console.WriteLine(re);
            Clipboard.SetText(re.ToString());
            Console.ReadKey();
        }
    }
}