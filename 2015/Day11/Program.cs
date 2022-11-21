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
        //Part 1
        static void Main(string[] args)
        {
            //var input = "cqjxjnds";
            var input = "abcdefgh";

            input = GenerateNextPassword(input);

            Console.WriteLine($"Result: {input}");
            Clipboard.SetText(input.ToString());

            Console.ReadKey();
        }

        private static string GenerateNextPassword(string oldPassword)
        {
            StringBuilder sb = new StringBuilder(oldPassword);            

            while (true)
            {
                Console.WriteLine(sb.ToString());

                int pos = sb.Length - 1;

                while (sb[pos] == 'z')
                {
                    sb[pos] = 'a';
                    pos--;
                }

                sb[pos]++;

                if (CheckPassword(sb.ToString()))
                {
                    break;
                }
            }


            return sb.ToString();
        }

        private static bool CheckPassword(string pwd)
        {
            var chars = new char[] { 'i', 'o', 'l' };

            foreach(var c in pwd)
            {
                if (chars.Contains(c))
                {
                    return false;
                }
            }

            var ok = false;

            for (int i = 0; i < pwd.Length - 2; i++)
            {
                if ((pwd[i] + 1 == pwd[i + 1] && pwd[i] + 2 == pwd[i + 2]))
                {
                    ok = true;
                    break;
                }
            }

            if (!ok)
            {
                return false;
            }

            //check double characters

            return true;
        }
    }
}