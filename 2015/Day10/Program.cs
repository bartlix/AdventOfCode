using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day10
{
    class Programm
    {
        [STAThread]
        //static void Main(string[] args)
        //{
        //    var input = "1113222113";

        //    for (var i = 0; i < 40; i++)
        //    {
        //        input = input.LookAndSay();
        //    }

        //    Console.WriteLine($"Result: {input.Length}");
        //    Clipboard.SetText(input.Length.ToString());

        //    Console.ReadKey();
        //}

        //Part 2
        static void Main(string[] args)
        {
            var input = "1113222113";

            for (var i = 0; i < 50; i++)
            {
                input = input.LookAndSay();
            }

            Console.WriteLine($"Result: {input.Length}");
            Clipboard.SetText(input.Length.ToString());

            Console.ReadKey();
        }
    }
}