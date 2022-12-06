using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Day06
{
    class Programm
    {
        [STAThread]
        // Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllText("Input.txt");
        //    //var input = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";

        //    var count = 0;

        //    for (var i = 3; i < input.Length; i++)
        //    {
        //        var search = input.Substring(i - 3, 4);

        //        var x = search.GroupBy(x => x).Select(x => new { Key = x.Key, Items = x}).ToList();

        //        var max = x.Max(x => x.Items.Count());

        //        if(max == 1)
        //        {
        //            count = i + 1;
        //            break;
        //        }
        //    }

        //    Console.WriteLine("--------------------------------------");

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());
        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Input.txt");
            //var input = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";

            var count = 0;

            for (var i = 13; i < input.Length; i++)
            {
                var search = input.Substring(i - 13, 14);

                var x = search.GroupBy(x => x).Select(x => new { Key = x.Key, Items = x }).ToList();

                var max = x.Max(x => x.Items.Count());

                if (max < 2)
                {
                    count = i + 1;
                    break;
                }
            }

            Console.WriteLine("--------------------------------------");

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());
            Console.ReadKey();
        }
    }
}