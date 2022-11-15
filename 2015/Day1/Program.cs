using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows;

namespace Day2
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var content = File.ReadAllText("Input.txt");

            //Part 1
            //var sum = content.Count(x => x == '(') - content.Count(x => x == ')');

            //Console.WriteLine(sum);
            //Clipboard.SetText(sum.ToString());


            //Part 2
            int sum = 0;
            int pos = 1;

            foreach(var item in content)
            {
                if (item == '(')
                {
                    sum++;
                }

                if (item == ')')
                {
                    sum--;
                }

                if(sum == -1)
                {
                    break;
                }

                pos++;
            }

            Console.WriteLine(pos);
            Clipboard.SetText(pos.ToString());

            Console.ReadKey();
        }
    }
}