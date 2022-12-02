using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;
using Day18;

namespace Day18
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var transParts = new List<(string key, string value)>();

            var action = false;

            string baseTxt = "";

            foreach (var line in input)
            {
                if (line == "")
                {
                    action = true;
                    continue;
                }

                if (action)
                {
                    baseTxt = line;
                    break;
                }

                var part = line.Split("=>");

                transParts.Add((part[0].Trim(), part[1].Trim()));
            }

            var result = new List<string>();

            StringBuilder sb = new StringBuilder();

            foreach (var part in transParts)
            {
                var regex = new Regex(Regex.Escape(part.key));
                var matches = regex.Matches(baseTxt);                

                foreach (Match m in matches)
                {
                    sb.Append(baseTxt.Substring(0, m.Index));
                    sb.Append(part.value);
                    sb.Append(baseTxt.Substring(m.Index + m.Length));

                    result.Add(sb.ToString());
                    sb.Clear();
                }
            }

            var count = result.Distinct().Count();

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());
            Console.ReadKey();
        }
    }
}