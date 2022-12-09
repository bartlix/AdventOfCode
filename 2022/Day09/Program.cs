using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Day09
{
    internal class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");
            //var content = File.ReadAllLines("Sample.txt");
            var sum = 0;

            var helpOne = new int[] { 1, -1 };
            var helpTwo = new int[] { 2, -2 };


            var visits = new List<(int y, int x)>();

            (int y, int x) headPos = new(0, 0);
            (int y, int x) tailPos = new(0, 0);

            visits.Add(tailPos);

            foreach (var item in content)
            {
                int x = headPos.x;
                int y = headPos.y;

                var parts = item.Split(' ');
                var distance = int.Parse(parts[1]);

                switch (parts[0])
                {
                    case "R":
                        x += distance;
                        break;
                    case "L":
                        x -= distance;
                        break;
                    case "U":
                        y += distance;
                        break;
                    case "D":
                        y -= distance;
                        break;
                }

                while (headPos != (y, x))
                {
                    if (headPos.x != x)
                    {
                        headPos.x += headPos.x > x ? -1 : 1;
                    }
                    else if (headPos.y != y)
                    {
                        headPos.y += headPos.y > y ? -1 : 1;
                    }

                    var diffX = headPos.x - tailPos.x;
                    var diffY = headPos.y - tailPos.y;

                    if ((Math.Abs(diffX) == 1 && Math.Abs(diffY) > 1) || (Math.Abs(diffY) == 1 && Math.Abs(diffX) > 1))
                    {
                        tailPos.x += diffX > 0 ? 1 : -1;
                        tailPos.y += diffY > 0 ? 1 : -1;
                        visits.Add(tailPos);
                    }
                    else if (Math.Abs(diffX) > 1)
                    {
                        tailPos.x += diffX > 0 ? 1 : -1;
                        visits.Add(tailPos);
                    }
                    else if (Math.Abs(diffY) > 1)
                    {
                        tailPos.y += diffY > 0 ? 1 : -1;
                        visits.Add(tailPos);
                    }
                }
            }

            sum = visits.Distinct().Count();

            Console.WriteLine(sum);
            Clipboard.SetText(sum.ToString());

            Console.ReadKey();
        }
    }
}