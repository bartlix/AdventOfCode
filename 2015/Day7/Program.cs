using System.IO;
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
            var content = File.ReadAllLines("Input.txt");
            //var content = File.ReadAllLines("Sample.txt");

            Dictionary<string, ushort> circuits = new();

            foreach (var circuit in content)
            {
                if(circuit == "0 -> c")
                {

                }

                var parts = circuit.Split("->");

                var left = parts[0].Trim().Split();
                var target = parts[1].Trim();

                CheckCircuit(circuits, target);

                if (left.Count() == 1)
                {
                    if (ushort.TryParse(left[0], out var result))
                    {
                        circuits[target] = result;
                    }
                    else
                    {
                        circuits[target] = circuits[left[0].Trim()];
                    }
                }

                if (left.Contains("AND") || left.Contains("OR") || left.Contains("LSHIFT")  || left.Contains("RSHIFT"))
                {
                    var a = left[0].Trim();
                    var b = left[2].Trim();

                    var isNumA = ushort.TryParse(a, out var numA);
                    var isNumB = ushort.TryParse(b, out var numB);

                    if (!isNumA)
                    {
                        CheckCircuit(circuits, a);
                    }

                    if (!isNumB)
                    {
                        CheckCircuit(circuits, b);
                    }

                    ushort lL = isNumA ? numA : circuits[a];
                    ushort rR = isNumB ? numB : circuits[b];

                    if (left.Contains("AND"))
                    {
                        circuits[target] = (ushort)(lL & rR);
                    }

                    if (left.Contains("OR"))
                    {
                        circuits[target] = (ushort)(lL | rR);
                    }

                    if (left.Contains("LSHIFT"))
                    {
                        circuits[target] = (ushort)(lL << rR);
                    }

                    if (left.Contains("RSHIFT"))
                    {
                        circuits[target] = (ushort)(lL >> rR);
                    }
                }

                if (left.Contains("NOT"))
                {
                    var a = left[1].Trim();

                    var isNumA = ushort.TryParse(a, out var numA);

                    if (!isNumA)
                    {
                        CheckCircuit(circuits, a);
                    }

                    ushort lL = isNumA ? numA : circuits[a];

                    circuits[target] = (ushort)(~lL & ushort.MaxValue);
                }
            }

            Console.WriteLine($"Result: {circuits["a"]}");
            Clipboard.SetText(circuits["a"].ToString());

            Console.ReadKey();
        }

        private static void CheckCircuit(Dictionary<string, ushort> circuits, string target)
        {
            if (!circuits.ContainsKey(target))
            {
                circuits.Add(target, 0);
            }
        }
    }
}