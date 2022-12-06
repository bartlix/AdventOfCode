using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day02
{
    class Programm
    {
        [STAThread]
        //Part 1
        //static void Main(string[] args)
        //{
        //    var input = File.ReadAllLines("Input.txt");
        //    //var input = File.ReadAllLines("Sample.txt");

        //    var sum = 0;

        //    foreach(var line in input)
        //    {
        //        var part = line.Split(' ');

        //        var left = part[0][0] - 'A';
        //        var right = part[1][0] - 'X';

        //        if (left == right)
        //        {
        //            sum += right + 1 + 3;
        //        }
        //        else if (left == 0 && right == 2)
        //        {
        //            sum += right + 1;
        //        }
        //        else if (left == 2 && right == 0)
        //        {
        //            sum += right + 1 + 6;
        //        }
        //        else
        //        if (right > left)
        //        {
        //            sum += right + 1 + 6;
        //        }
        //        else
        //        {
        //            sum += right + 1;
        //        }
        //    }

        //    // A X Rock             1 2 3    0 3 6
        //    // B Y Paper
        //    // C Z Scissors


        //    Console.WriteLine("--------------------------------------");

        //    var count = sum;

        //    Console.WriteLine(count);
        //    Clipboard.SetText(count.ToString());
        //    Console.ReadKey();
        //}

        // Part 2
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            //var input = File.ReadAllLines("Sample.txt");

            var sum = 0;

            foreach (var line in input)
            {
                var part = line.Split(' ');

                var left = part[0][0] - 'A';
                int right = -1;
                var result = part[1][0];



                switch (result)
                {
                    case 'X':
                        right = left - 1;
                        break;
                    case 'Y':
                        right = left;
                        break;
                    case 'Z':
                        right = left + 1;
                        break;
                }


                if (right < 0)
                {
                    right = 2;
                }
                else
                if (right > 2)
                {
                    right = 0;
                }


                if (left == right)
                {
                    sum += right + 1 + 3;
                }
                else if (left == 0 && right == 2)
                {
                    sum += right + 1;
                }
                else if (left == 2 && right == 0)
                {
                    sum += right + 1 + 6;
                }
                else
                if (right > left)
                {
                    sum += right + 1 + 6;
                }
                else
                {
                    sum += right + 1;
                }
            }

            // A X Rock             1 2 3    0 3 6
            // B Y Paper
            // C Z Scissors


            Console.WriteLine("--------------------------------------");

            var count = sum;

            Console.WriteLine(count);
            Clipboard.SetText(count.ToString());
            Console.ReadKey();
        }
    }
}