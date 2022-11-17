using System.IO;
using System.Windows;

namespace Day6
{
    class Programm
    {
        [STAThread]
        // Part 1
        //static void Main(string[] args)
        //{
        //    var content = File.ReadAllLines("Input.txt");

        //    Dictionary<(int x, int y), bool> playground = new ();

        //    for (var x = 0; x < 1000; x++)
        //    {
        //        for (var y = 0; y < 1000; y++)
        //        {
        //            playground.Add((x,y), false);
        //        }
        //    }

        //    int rowCount = 0;
        //    foreach (var row in content)
        //    {
        //        Console.WriteLine(rowCount++);
        //        ApplyAction(row, playground);
        //    }

        //    var count = playground.Where(x => x.Value).Count();
        //    Console.WriteLine($"Result: {count}");
        //    Clipboard.SetText(count.ToString());

        //    Console.ReadKey();
        //}

        //private static void ApplyAction(string row, Dictionary<(int x,int y), bool> playground)
        //{
        //    LightAction action = LightAction.None;

        //    if (row.StartsWith("turn on"))
        //    {
        //        action = LightAction.On;
        //        row = row.Replace("turn on ", "");
        //    }

        //    if (row.StartsWith("turn off"))
        //    {
        //        action = LightAction.Off;
        //        row = row.Replace("turn off ", "");
        //    }

        //    if (row.StartsWith("toggle"))
        //    {
        //        action = LightAction.Toggle;
        //        row = row.Replace("toggle ", "");
        //    }

        //    var startPoint = row.Split(' ')[0].Split(',');
        //    var startX = int.Parse(startPoint[0]);
        //    var startY = int.Parse(startPoint[1]);

        //    row = row.Substring(row.IndexOf(' ') + 1);

        //    row = row.Replace("through ", "");

        //    var endPoint = row.Split(',');
        //    var endX = int.Parse(endPoint[0]);
        //    var endY = int.Parse(endPoint[1]);

        //    for (var x = startX; x <= endX; x++)
        //    {
        //        for (var y = startY; y <= endY; y++)
        //        {
        //            switch (action)
        //            {
        //                case LightAction.On:
        //                    playground[(x,y)] = true;
        //                    break;
        //                case LightAction.Off:
        //                    playground[(x, y)] = false;
        //                    break;
        //                case LightAction.Toggle:
        //                    playground[(x, y)] = !playground[(x, y)];
        //                    break;
        //            }
        //        }
        //    }
        //}

        //Part 2
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");

            Dictionary<(int x, int y), int> playground = new();

            for (var x = 0; x < 1000; x++)
            {
                for (var y = 0; y < 1000; y++)
                {
                    playground.Add((x, y), 0);
                }
            }

            int rowCount = 0;
            foreach (var row in content)
            {
                Console.WriteLine(rowCount++);
                ApplyAction(row, playground);
            }

            var count = playground.Sum(x => x.Value);
            Console.WriteLine($"Result: {count}");
            Clipboard.SetText(count.ToString());

            Console.ReadKey();
        }

        private static void ApplyAction(string row, Dictionary<(int x, int y), int> playground)
        {
            LightAction action = LightAction.None;

            if (row.StartsWith("turn on"))
            {
                action = LightAction.On;
                row = row.Replace("turn on ", "");
            }

            if (row.StartsWith("turn off"))
            {
                action = LightAction.Off;
                row = row.Replace("turn off ", "");
            }

            if (row.StartsWith("toggle"))
            {
                action = LightAction.Toggle;
                row = row.Replace("toggle ", "");
            }

            var startPoint = row.Split(' ')[0].Split(',');
            var startX = int.Parse(startPoint[0]);
            var startY = int.Parse(startPoint[1]);

            row = row.Substring(row.IndexOf(' ') + 1);

            row = row.Replace("through ", "");

            var endPoint = row.Split(',');
            var endX = int.Parse(endPoint[0]);
            var endY = int.Parse(endPoint[1]);

            for (var x = startX; x <= endX; x++)
            {
                for (var y = startY; y <= endY; y++)
                {
                    switch (action)
                    {
                        case LightAction.On:
                            playground[(x, y)] += 1;
                            break;
                        case LightAction.Off:
                            playground[(x, y)] -= 1;

                            if (playground[(x, y)] < 0)
                            {
                                playground[(x, y)] = 0;
                            }

                            break;
                        case LightAction.Toggle:
                            playground[(x, y)] += 2;
                            break;
                    }
                }
            }
        }

        private enum LightAction
        {
            None = 0,
            On = 1,
            Off = 2,
            Toggle = 3,
        }
    }
}