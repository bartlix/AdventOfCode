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

            var lookFor = new AuntInfo 
            {
                Children = 3,
                Cats = 7,
                Samoyeds = 2,
                Pomeranians = 3,
                Akitas = 0,
                Vizslas = 0,
                Goldfish = 5,
                Trees = 3,
                Cars = 2,
                Perfumes = 1
            };

            var aunt = auntList.OrderByDescending(x => x.GetScore(lookFor)).FirstOrDefault();

            Console.WriteLine(aunt.Id);
            Clipboard.SetText(aunt.Id.ToString());
            Console.ReadKey();
        }
    }
}