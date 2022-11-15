using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
namespace Day2
{
    class Programm
    {
        [STAThread]
        // Part 1
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");

            var niceCount = 0;

            foreach(var line in content)
            {
                if(line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy"))
                {
                    continue;
                }

                var reg = new Regex("[aeiou]");
                var match = reg.Matches(line);

                if (match.Count() < 3)
                {
                    continue;
                }

                var reg2 = new Regex("(\\w)\\1{1}");
                var match2 = reg2.Matches(line);

                if (match2.Count() == 0)
                {
                    continue;
                }

                niceCount++;
            }
            

            Console.WriteLine(niceCount);
            Clipboard.SetText(niceCount.ToString());

            Console.ReadKey();
        }
    }
}