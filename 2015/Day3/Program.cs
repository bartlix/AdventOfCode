using System.IO;
using System.Windows;
namespace Day3
{
    class Programm
    {
        [STAThread]
        // Part 1
        //static void Main(string[] args)
        //{
        //    var content = File.ReadAllText("Input.txt");

        //    Dictionary<KeyValuePair<int, int>, int> presents = new Dictionary<KeyValuePair<int, int>, int>();

        //    int x = 0;
        //    int y = 0;

        //    presents.Add(new KeyValuePair<int, int>(x, y), 1);

        //    foreach (var item in content)
        //    {
        //        if (item == '^')
        //        {
        //            y++;
        //        }

        //        if (item == 'v')
        //        {
        //            y--;
        //        }

        //        if (item == '>')
        //        {
        //            x++;
        //        }

        //        if (item == '<')
        //        {
        //            x--;
        //        }

        //        var pos = new KeyValuePair<int, int>(x, y);

        //        if (presents.ContainsKey(pos))
        //        {
        //            presents[pos]++;
        //        }
        //        else
        //        {
        //            presents.Add(new KeyValuePair<int, int>(x, y), 1);
        //        }
        //    }

        //    Console.WriteLine(presents.Count);
        //    Clipboard.SetText(presents.Count.ToString());

        //    Console.ReadKey();
        //}

        //Part 2
        static void Main(string[] args)
        {
            var content = File.ReadAllText("Input.txt");

            Dictionary<KeyValuePair<int, int>, int> presents = new Dictionary<KeyValuePair<int, int>, int>();

            int xSanta = 0;
            int ySanta = 0;

            int xBot = 0;
            int yBot = 0;

            int count = 0;

            presents.Add(new KeyValuePair<int, int>(0, 0), 2);

            foreach (var item in content)
            {
                int x, y;
                if (count % 2 == 0)
                {
                    if (item == '^')
                    {
                        ySanta++;
                    }

                    if (item == 'v')
                    {
                        ySanta--;
                    }

                    if (item == '>')
                    {
                        xSanta++;
                    }

                    if (item == '<')
                    {
                        xSanta--;
                    }

                    x = xSanta;
                    y = ySanta;
                }
                else
                {
                    if (item == '^')
                    {
                        yBot++;
                    }

                    if (item == 'v')
                    {
                        yBot--;
                    }

                    if (item == '>')
                    {
                        xBot++;
                    }

                    if (item == '<')
                    {
                        xBot--;
                    }

                    x = xBot;
                    y = yBot;
                }

                var pos = new KeyValuePair<int, int>(x, y);

                if (presents.ContainsKey(pos))
                {
                    presents[pos]++;
                }
                else
                {
                    presents.Add(new KeyValuePair<int, int>(x, y), 1);
                }

                count++;
            }

            Console.WriteLine(presents.Count);
            Clipboard.SetText(presents.Count.ToString());

            Console.ReadKey();
        }
    }
}