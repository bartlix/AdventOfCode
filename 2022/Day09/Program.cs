using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Day09
{
    internal class Programm
    {
        [STAThread]
        // Part 1
        //static void Main(string[] args)
        //{
        //    var content = File.ReadAllLines("Input.txt");
        //    //var content = File.ReadAllLines("Sample.txt");
        //    var sum = 0;

        //    var visits = new List<(int y, int x)>();

        //    (int y, int x) headPos = new(0, 0);
        //    (int y, int x) tailPos = new(0, 0);

        //    visits.Add(tailPos);

        //    foreach (var item in content)
        //    {
        //        int x = headPos.x;
        //        int y = headPos.y;

        //        var parts = item.Split(' ');
        //        var distance = int.Parse(parts[1]);

        //        switch (parts[0])
        //        {
        //            case "R":
        //                x += distance;
        //                break;
        //            case "L":
        //                x -= distance;
        //                break;
        //            case "U":
        //                y += distance;
        //                break;
        //            case "D":
        //                y -= distance;
        //                break;
        //        }

        //        while (headPos != (y, x))
        //        {
        //            if (headPos.x != x)
        //            {
        //                headPos.x += headPos.x > x ? -1 : 1;
        //            }
        //            else if (headPos.y != y)
        //            {
        //                headPos.y += headPos.y > y ? -1 : 1;
        //            }

        //            var diffX = headPos.x - tailPos.x;
        //            var diffY = headPos.y - tailPos.y;

        //            if ((Math.Abs(diffX) == 1 && Math.Abs(diffY) > 1) || (Math.Abs(diffY) == 1 && Math.Abs(diffX) > 1))
        //            {
        //                tailPos.x += diffX > 0 ? 1 : -1;
        //                tailPos.y += diffY > 0 ? 1 : -1;
        //                visits.Add(tailPos);
        //            }
        //            else if (Math.Abs(diffX) > 1)
        //            {
        //                tailPos.x += diffX > 0 ? 1 : -1;
        //                visits.Add(tailPos);
        //            }
        //            else if (Math.Abs(diffY) > 1)
        //            {
        //                tailPos.y += diffY > 0 ? 1 : -1;
        //                visits.Add(tailPos);
        //            }
        //        }
        //    }

        //    sum = visits.Distinct().Count();

        //    Console.WriteLine(sum);
        //    Clipboard.SetText(sum.ToString());

        //    Console.ReadKey();
        //}
        // Part 2
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");
            //var content = File.ReadAllLines("Sample.txt");
            var sum = 0;

            var visits = new List<(int y, int x)>();

            var ropePos = new Dictionary<string, (int y, int x)>();
            
            ropePos.Add("H", (0, 0));

            for(var i = 1; i <= 9; i++)
            {
                ropePos.Add(i.ToString(), (0, 0));
            }

            visits.Add(ropePos["9"]);

            foreach (var item in content)
             {
                int x = ropePos["H"].x;
                int y = ropePos["H"].y;

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

                while (ropePos["H"] != (y, x))
                {
                    if (ropePos["H"].x != x)
                    {
                        var p = ropePos["H"];
                        p.x += ropePos["H"].x > x ? -1 : 1;
                        ropePos["H"] = p;
                    }
                    else if (ropePos["H"].y != y)
                    {
                        var p = ropePos["H"];
                        p.y += ropePos["H"].y > y ? -1 : 1;
                        ropePos["H"] = p;
                    }

                    var prePos = ropePos["H"];
                    var oldTail = ropePos["9"];

                    foreach(var pos in ropePos.Skip(1))
                    {
                        var tailPos = pos.Value;

                        var diffX = prePos.x - tailPos.x;
                        var diffY = prePos.y - tailPos.y;

                        if ((Math.Abs(diffX) >= 1 && Math.Abs(diffY) > 1) || (Math.Abs(diffY) >= 1 && Math.Abs(diffX) > 1))
                        {
                            tailPos.x += diffX > 0 ? 1 : -1;
                            tailPos.y += diffY > 0 ? 1 : -1;
                        }
                        else
                        if (Math.Abs(diffX) > 1)
                        {
                            tailPos.x += diffX > 0 ? 1 : -1;
                        }
                        else if (Math.Abs(diffY) > 1)
                        {
                            tailPos.y += diffY > 0 ? 1 : -1;
                        }
                        ropePos[pos.Key] = tailPos;
                        prePos = tailPos;
                    }

                    if (oldTail != ropePos["9"])
                    {
                        visits.Add(ropePos["9"]);
                    }
                }
            }

            sum = visits.Distinct().Count();

            Console.WriteLine(sum);
            Clipboard.SetText(sum.ToString());

            Console.ReadKey();
        }

        private static void Display(Dictionary<string, (int y, int x)> ropePos)
        {
            var maxX = Math.Max(ropePos.Max(x => x.Value.x), 10);
            var maxY = Math.Max(ropePos.Max(x => x.Value.y), 10);

            StringBuilder sb  = new StringBuilder();

            for (var y = maxY - 1; y >= 0; y--)
            {
                for (var x = 0; x < maxX; x++)
                {
                    if (ropePos.Where(p => p.Value == (y, x)).Count() > 0)
                    {
                        var bla = ropePos.First(p => p.Value == (y, x));

                        sb.Append(bla.Key);
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine("------------------------------");
        }
    }
}