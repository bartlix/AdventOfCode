using System.IO;
using System.Windows;
namespace Day4
{
    class Programm
    {
        [STAThread]
        // Part 1
        //static void Main(string[] args)
        //{
        //    var content = "yzbqklnj";

        //    var result = "";

        //    for (var i = 0; i < 1000000; i++) 
        //    {
        //        var tryout = $"{content}{i:D6}";

        //        var bla = CreateMD5(tryout);

        //        if (bla.StartsWith("00000"))
        //        {
        //            result = $"{i:D6}";
        //            break;
        //        }
        //    }

        //    Console.WriteLine(result);
        //    Clipboard.SetText(result);

        //    Console.ReadKey();
        //}

        //Part 2
        static void Main(string[] args)
        {
            var content = "yzbqklnj";

            var result = "";

            for (var i = 0; i < int.MaxValue; i++)
            {
                var tryout = $"{content}{i}";

                var bla = CreateMD5(tryout);

                if (bla.StartsWith("000000"))
                {
                    result = $"{i}";
                    break;
                }
            }

            Console.WriteLine(result);
            Clipboard.SetText(result);

            Console.ReadKey();
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}