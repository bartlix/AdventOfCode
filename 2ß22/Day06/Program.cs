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
        static void Main(string[] args)
        {
            //var input = File.ReadAllText("Input.txt");
            var input = "nppdvjthqldpwncqszvftbrmjlhg";

            var sb = new StringBuilder();
            sb.Append(input.Substring(0, 4));
            input = input.Substring(4);

            for (var i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]);
                if(sb.Length < 4)
                {
                    continue;
                }
            }

            Console.WriteLine("--------------------------------------");

            Console.WriteLine(sb.Length);
            Clipboard.SetText(sb.Length.ToString());
            Console.ReadKey();
        }
    }
}