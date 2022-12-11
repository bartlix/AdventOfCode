using System.IO;
using System.Text;
using System.Windows;

namespace Day10
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
        //    var x = 1;
        //    var cyclesCount = 2;
        //    var cycles = new Dictionary<int, int>
        //    {
        //        { 1, 1 }
        //    };

        //    foreach (var line in content)
        //    {
        //        var parts = line.Split(' ');

        //        if (parts[0] == "noop")
        //        {
        //            cycles.Add(cyclesCount++, x);
        //        }
        //        else if (parts[0] == "addx")
        //        {
        //            cycles.Add(cyclesCount++, x);

        //            var val = int.Parse(parts[1]);

        //            x += val;
        //            cycles.Add(cyclesCount++, x);
        //        }
        //    }

        //    sum = 20 * cycles[20] + 60 * cycles[60] + 100 * cycles[100] + 140 * cycles[140] + 180 * cycles[180] + 220 * cycles[220];

        //    Console.WriteLine(sum);
        //    Clipboard.SetText(sum.ToString());

        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");
            //var content = File.ReadAllLines("Sample.txt");
            
            var x = 1;
            var cyclesCount = 2;
            var cycles = new Dictionary<int, int>
            {
                { 1, 1 }
            };

            foreach (var line in content)
            {
                var parts = line.Split(' ');

                if (parts[0] == "noop")
                {
                    cycles.Add(cyclesCount++, x);
                }
                else if (parts[0] == "addx")
                {
                    cycles.Add(cyclesCount++, x);

                    var val = int.Parse(parts[1]);

                    x += val;
                    cycles.Add(cyclesCount++, x);
                }
            }

            var sb = new StringBuilder();

            foreach (var c in cycles)
            {
                var a = c.Key % 40;

                var spritePos = new int[] { c.Value, c.Value + 1, c.Value + 2 };

                sb.Append(spritePos.Contains(a) ? "#" : ".");

                if ((c.Key % 40) == 0)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
            }

            Console.ReadKey();
        }
    }
}