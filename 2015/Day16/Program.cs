using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day16
{
    class Programm
    {
        [STAThread]
        //Part 1
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");

            var auntList = new List<AuntInfo>();

            foreach(var line in input) 
            { 
                auntList.Add(new AuntInfo(line));
            }


            var aunt = auntList.Where(x => x.Children == 3 && x.Cats == 7).ToList();

            //Console.WriteLine(re);
            //Clipboard.SetText(re.ToString());
            Console.ReadKey();
        }
    }
}