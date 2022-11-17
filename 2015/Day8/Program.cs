using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day2
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

            foreach (var row in input)
            {
                var str = GetString(row);

                var zahl = row.Length - str.Length;

                sum += zahl;
            }

            Console.WriteLine($"Result: {sum}");
            Clipboard.SetText(sum.ToString());

            Console.ReadKey();
        }

        private static string GetString(string input)
        {
            var s = input.Substring(1, input.Length - 2);

            s = Regex.Unescape(s);

            return s;
        }
    }
}