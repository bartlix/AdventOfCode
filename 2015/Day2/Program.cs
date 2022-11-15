using System.IO;
using System.Windows;
namespace Day2
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");

            //int sum = 0;
            int ribbon = 0;

            foreach (var row in content)
            {
                var items = row.Split('x');

                var l = int.Parse(items[0]);
                var w = int.Parse(items[1]);
                var h = int.Parse(items[2]);

                //var s = 2 * l * w + 2 * w * h + 2 * h * l;

                //var x = new int[] { l * w, w * h, h * l };

                //sum += s + x.Min();
                var s = new List<int> { l, w, h };
                s.Sort();

                ribbon += s[0] + s[0] + s[1] + s[1] + (l * w * h);
            }

            // Part 1
            //Console.WriteLine(sum);
            //Clipboard.SetText(sum.ToString());
            
            //Part 2
            Console.WriteLine(ribbon);
            Clipboard.SetText(ribbon.ToString());

            Console.ReadKey();
        }
    }
}