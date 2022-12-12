using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows;

namespace Day11
{
    internal class Programm
    {
        [STAThread]
        // Part 1
        static void Main(string[] args)
        {
            //var content = File.ReadAllLines("Input.txt");
            var content = File.ReadAllLines("Sample.txt");
            long sum = 0;

            var monkeys = new List<MonkeyInfo>();

            MonkeyInfo currentMonkey = null;

            foreach (var line in content)
            {
                if (line.StartsWith("Monkey"))
                {
                    var parts = line.Replace(":", "").Split(' ');

                    currentMonkey = new MonkeyInfo { Id = int.Parse(parts[1]) };
                }
                else if (line.StartsWith("  Starting items:"))
                {
                    var parts = line.Substring(18).Split(',');
                    foreach (var p in parts)
                    {
                        currentMonkey.Items.Add(int.Parse(p));
                    }
                }
                else if (line.StartsWith("  Operation:"))
                {
                    var parts = line.Substring(13).Split("=");

                    currentMonkey.Operation = parts[1].Trim();
                }
                else if (line.StartsWith("  Test:"))
                {
                    var parts = line.Substring(8).Split(' ');

                    currentMonkey.Divisor = int.Parse(parts.Last());
                }
                else if (line.StartsWith("    If true:"))
                {
                    var parts = line.Substring(13).Split(' ');
                    currentMonkey.TrueId = int.Parse(parts.Last());
                }
                else if (line.StartsWith("    If false:"))
                {
                    var parts = line.Substring(14).Split(' ');
                    currentMonkey.FalseId = int.Parse(parts.Last());
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    monkeys.Add(currentMonkey);
                }
            }

            monkeys.Add(currentMonkey);

            for (var c = 0; c < 10000; c++)
            {
                foreach (var m in monkeys)
                {
                    foreach (var item in m.Items.ToList())
                    {
                        m.InspectCount++;
                        m.Items.Remove(item);

                        var newWorryLevel = m.GetWorryLevel(item);

                        //var newWorryLevel = (level / 3);

                        if (newWorryLevel % m.Divisor == 0)
                        {
                            var nextMonkey = monkeys.FirstOrDefault(x => x.Id == m.TrueId);
                            if (nextMonkey != null)
                            {
                                nextMonkey.Items.Add(newWorryLevel);
                            }
                        }
                        else
                        {
                            var nextMonkey = monkeys.FirstOrDefault(x => x.Id == m.FalseId);
                            if (nextMonkey != null)
                            {
                                nextMonkey.Items.Add(newWorryLevel);
                            }
                        }
                    }
                }


                if(c == 20 || c % 1000 == 0)
                {
                    Console.WriteLine($"== After round {c} ==");

                    Display(monkeys);
                    Console.ReadKey();
                }
            }

            var ordered = monkeys.OrderByDescending(x => x.InspectCount).ToList();

            sum = ordered[0].InspectCount * ordered[1].InspectCount;

            Console.WriteLine(sum);
            Clipboard.SetText(sum.ToString());

            Console.ReadKey();
        }

        private static void Display(List<MonkeyInfo> monkeys)
        {
            foreach(var m in monkeys)
            {
                Console.WriteLine($"Monkey {m.Id} inspected items {m.InspectCount} times");
            }
        }
    }
}