using System.IO;
using System.Windows;
namespace Day2
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            var content = File.ReadAllLines("Input.txt");

            
            Console.WriteLine(ribbon);
            Clipboard.SetText(ribbon.ToString());

            Console.ReadKey();
        }
    }
}