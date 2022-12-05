using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Day05
{
    class Programm
    {
        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    List<string> stack = new List<string>();
        //    List<string> moves = new List<string>();

        //    var addMoves = false;

        //    foreach (var line in input)
        //    {
        //        if (line == "")
        //        {
        //            addMoves = true;
        //            continue;
        //        }

        //        if (addMoves)
        //        {
        //            moves.Add(line);
        //        }
        //        else
        //        {
        //            stack.Add(line);
        //        }
        //    }


        //    var supplyStack = new Dictionary<int, List<string>>();

        //    var numbers = stack.Last();

        //    numbers.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList().ForEach(x =>
        //    {
        //        supplyStack.Add(int.Parse(x), new List<string>());
        //    });

        //    stack.Remove(numbers);

        //    foreach (var line in stack)
        //    {
        //        for (var i = 0; i < supplyStack.Count; i++)
        //        {
        //            if (i == 3)
        //            {

        //            }

        //            var index = 0;
        //            if (i != 0)
        //            {
        //                index = i * 3 + (i * 1);
        //            }

        //            var part = line.Substring(index, 3).Trim();

        //            if (part != "")
        //            {
        //                supplyStack[i + 1].Insert(0, part.Replace("[", "").Replace("]", ""));
        //            }
        //        }
        //    }

        //    //Display(supplyStack);

        //    foreach (var move in moves)
        //    {
        //        //Console.WriteLine(move);

        //        var parts = move.Split(' ');

        //        var anz = int.Parse(parts[1]);

        //        var from = int.Parse(parts[3]);

        //        var to = int.Parse(parts[5]);

        //        for (var i = 0; i < anz; i++)
        //        {
        //            var item = supplyStack[from].LastOrDefault();

        //            if (item != null)
        //            {
        //                supplyStack[from].RemoveAt(supplyStack[from].Count - 1);
        //                supplyStack[to].Add(item);
        //            }
        //        }

        //        //Display(supplyStack);
        //        //Console.WriteLine();
        //        //Console.WriteLine("---------");
        //        //Console.WriteLine();
        //        //Console.ReadKey();
        //    }

        //    StringBuilder sb = new StringBuilder();

        //    foreach (var item in supplyStack)
        //    {
        //        var bla = item.Value.LastOrDefault();
        //        if (bla != null)
        //        {
        //            sb.Append(bla);
        //        }
        //    }

        //    Console.WriteLine("--------------------------------------");

        //    Console.WriteLine(sb.ToString());
        //    Clipboard.SetText(sb.ToString());
        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            List<string> stack = new List<string>();
            List<string> moves = new List<string>();

            var addMoves = false;

            foreach (var line in input)
            {
                if (line == "")
                {
                    addMoves = true;
                    continue;
                }

                if (addMoves)
                {
                    moves.Add(line);
                }
                else
                {
                    stack.Add(line);
                }
            }


            var supplyStack = new Dictionary<int, List<string>>();

            var numbers = stack.Last();

            numbers.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList().ForEach(x =>
            {
                supplyStack.Add(int.Parse(x), new List<string>());
            });

            stack.Remove(numbers);

            foreach (var line in stack)
            {
                for (var i = 0; i < supplyStack.Count; i++)
                {
                    if (i == 3)
                    {

                    }

                    var index = 0;
                    if (i != 0)
                    {
                        index = i * 3 + (i * 1);
                    }

                    var part = line.Substring(index, 3).Trim();

                    if (part != "")
                    {
                        supplyStack[i + 1].Insert(0, part.Replace("[", "").Replace("]", ""));
                    }
                }
            }

            //Display(supplyStack);

            foreach (var move in moves)
            {
                //Console.WriteLine(move);

                var parts = move.Split(' ');

                var anz = int.Parse(parts[1]);

                var from = int.Parse(parts[3]);

                var to = int.Parse(parts[5]);

                var buff = new List<string>();

                for (var i = 0; i < anz; i++)
                {
                    var item = supplyStack[from].LastOrDefault();

                    if (item != null)
                    {
                        supplyStack[from].RemoveAt(supplyStack[from].Count - 1);
                        buff.Insert(0, item);
                    }
                }

                foreach (var b in buff)
                {
                    supplyStack[to].Add(b);
                }

                //Display(supplyStack);
                //Console.WriteLine();
                //Console.WriteLine("---------");
                //Console.WriteLine();
                //Console.ReadKey();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in supplyStack)
            {
                var bla = item.Value.LastOrDefault();
                if (bla != null)
                {
                    sb.Append(bla);
                }
            }

            Console.WriteLine("--------------------------------------");

            Console.WriteLine(sb.ToString());
            Clipboard.SetText(sb.ToString());
            Console.ReadKey();
        }

        private static void Display(Dictionary<int, List<string>> supplyStack)
        {
            var max = supplyStack.Max(x => x.Value.Count);
            var sb = new StringBuilder();


            for (var i = max - 1; i >= 0; i--)
            {
                foreach (var a in supplyStack)
                {
                    if (i <= a.Value.Count - 1)
                    {
                        sb.Append($"[{a.Value[i]}]");
                    }
                    else
                    {
                        sb.Append("   ");
                    }

                    sb.Append(' ');
                }

                sb.AppendLine();
            }

            foreach (var a in supplyStack.Keys)
            {
                sb.Append($" {a}  ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}