using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Day11
{
    class Programm
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Part 1
            //var input = "cqjxjnds";

            //Part 2
            var input = "cqjxxyzz";

            input = FindNextPassword(input);

            Console.WriteLine($"Result: {input}");
            Clipboard.SetText(input);

            Console.ReadKey();
        }

        private static string FindNextPassword(string pwd)
        {
            StringBuilder sb = new StringBuilder(pwd);

            while (true)
            {
                //Console.WriteLine(sb.ToString());

                var pos = sb.Length - 1;

                while (sb[pos] == 'z')
                {
                    sb[pos] = 'a';
                    pos--;
                }

                sb[pos]++;

                if (CheckPasswordOK(sb.ToString()))
                {
                    break;
                }
            }

            return sb.ToString();
        }

        private static bool CheckPasswordOK(string pwd)
        {
            if (pwd.Contains('i') || pwd.Contains('o') || pwd.Contains('l'))
            {
                return false;
            }

            var ok = false;

            for (int i = 0; i < pwd.Length - 2; i++)
            {
                if (pwd[i] + 1 == pwd[i + 1] && pwd[i] + 2 == pwd[i + 2])
                {
                    ok = true;
                }
            }

            if (!ok)
            {
                return false;
            }

            var d = new Dictionary<string, int>();

            for (var i = 0; i < pwd.Length - 1; i += 1)
            {
                if (pwd[i] == pwd[i + 1])
                {
                    if (!d.ContainsKey($"{pwd[i]}{pwd[i + 1]}"))
                    {
                        d.Add($"{pwd[i]}{pwd[i + 1]}", 1);
                    }
                }
            }

            if (d.Count < 2)
            {
                return false;
            }

            return true;
        }
    }
}