using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day7
{
    class Programm
    {
        public static Dictionary<string, ushort> Circuits = new();

        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    var basis = new Dictionary<string, bool>(input.Select(x => new KeyValuePair<string, bool>(x, false)));

        //    while (!basis.All(x => x.Value))
        //    {
        //        ActionMethod(basis);

        //        Console.WriteLine($"Anzahl: {basis.Count(x => x.Value)}/{basis.Count()}");
        //    }

        //    Console.WriteLine("----------------------------------------------------");

        //    Console.WriteLine($"Result: {Circuits["a"]}");
        //    Clipboard.SetText(Circuits["a"].ToString());

        //    Console.ReadKey();
        //}

        //Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var basis = new Dictionary<string, bool>(input.Select(x => new KeyValuePair<string, bool>(x, false)));

            while (!basis.All(x => x.Value))
            {
                ActionMethod(basis);

                Console.WriteLine($"Anzahl: {basis.Count(x => x.Value)}/{basis.Count()}");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Result: {Circuits["a"]}");
            Clipboard.SetText(Circuits["a"].ToString());
            Console.WriteLine("----------------------------------------------------");

            basis.Remove("14146 -> b");
            basis.Add($"{Circuits["a"]} -> b", false);

            Circuits.Clear();

            foreach (var item in basis)
            {
                basis[item.Key] = false;
            }
                        
            while (!basis.All(x => x.Value))
            {
                ActionMethod(basis);

                Console.WriteLine($"Anzahl: {basis.Count(x => x.Value)}/{basis.Count()}");
            }

            Console.WriteLine($"Result: {Circuits["a"]}");
            Clipboard.SetText(Circuits["a"].ToString());

            Console.ReadKey();
        }

        private static void ActionMethod(Dictionary<string, bool> basis)
        {
            foreach (var circuit in basis.Where(x => !x.Value).Select(x => x.Key))
            {
                var parts = circuit.Split("->");

                var left = parts[0].Trim().Split();
                var target = parts[1].Trim();

                if (left.Count() == 1)
                {
                    if (ushort.TryParse(left[0], out var result))
                    {
                        if (SetValue(target, result))
                        {
                            basis[circuit] = true;
                            break;
                        }
                    }
                    else
                    {
                        if (SetValueFromVariable(target, left[0].Trim()))
                        {
                            basis[circuit] = true;
                            continue;
                        }
                    }
                }

                if (left.Contains("AND") || left.Contains("OR") || left.Contains("LSHIFT") || left.Contains("RSHIFT"))
                {
                    var a = left[0].Trim();
                    var b = left[2].Trim();

                    var isNumA = ushort.TryParse(a, out var numA);
                    var isNumB = ushort.TryParse(b, out var numB);

                    if (!isNumA)
                    {
                        if (!Circuits.ContainsKey(a))
                        {
                            continue;
                        }
                    }

                    if (!isNumB)
                    {
                        if (!Circuits.ContainsKey(b))
                        {
                            continue;
                        }
                    }

                    ushort lL = isNumA ? numA : Circuits[a];
                    ushort rR = isNumB ? numB : Circuits[b];

                    if (left.Contains("AND"))
                    {
                        if (SetValue(target, (ushort)(lL & rR)))
                        {
                            basis[circuit] = true;
                            break;
                        }
                    }

                    if (left.Contains("OR"))
                    {
                        if (SetValue(target, (ushort)(lL | rR)))
                        {
                            basis[circuit] = true;
                            break;
                        }
                    }

                    if (left.Contains("LSHIFT"))
                    {
                        if (SetValue(target, (ushort)(lL << rR)))
                        {
                            basis[circuit] = true;
                            break;
                        }
                    }

                    if (left.Contains("RSHIFT"))
                    {
                        if (SetValue(target, (ushort)(lL >> rR)))
                        {
                            basis[circuit] = true;
                            break;
                        }
                    }
                }

                if (left.Contains("NOT"))
                {
                    var a = left[1].Trim();

                    var isNumA = ushort.TryParse(a, out var numA);

                    if (isNumA)
                    {
                        if (SetValue(target, (ushort)(~numA)))
                        {
                            basis[circuit] = true;
                            break;
                        }
                    }
                    else
                    {
                        if (Circuits.ContainsKey(a))
                        {
                            if (SetValue(target, (ushort)~Circuits[a]))
                            {
                                basis[circuit] = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static bool SetValue(string target, ushort result)
        {
            if (!Circuits.ContainsKey(target))
            {
                Circuits.Add(target, result);
            }
            else
            {
                Circuits[target] = result;
            }

            return true;
        }

        private static bool SetValueFromVariable(string target, string variable)
        {
            if (Circuits.ContainsKey(variable))
            {
                return SetValue(target, Circuits[variable]);
            }

            return false;
        }
    }
}