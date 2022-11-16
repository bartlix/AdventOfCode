using System.IO;
using System.Windows;

namespace Day2
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            //var content = File.ReadAllLines("Input.txt");
            var content = new string[] { "123 -> x", "x AND y -> z", "p LSHIFT 2 -> q", "NOT e -> f" };
            Dictionary<string, ushort> circuits = new ();

            foreach (var circuit in content)
            {
                var parts = circuit.Split ("->");

                var target = parts[1].Trim();
                var action = parts[0].Trim();

                if (!circuits.ContainsKey(target))
                {
                    circuits.Add(target, 0);
                }

                if (ushort.TryParse(action, out var value) && value > 0) 
                {
                    circuits[target] = value;
                    continue;
                }

                var actionParts = action.Split(' ');
                
            }

            //Console.WriteLine($"Result: {count}");
            //Clipboard.SetText(count.ToString());

            Console.ReadKey();
        }
    }
}