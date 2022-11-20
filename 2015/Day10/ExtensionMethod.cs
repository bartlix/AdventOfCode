using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ExtensionMethod
    {
        public static string LookAndSay(this string input)
        {
            if(input.Length == 1)
            {
                return $"1{input}";
            }

            StringBuilder sb = new StringBuilder();

            int count = 1;

            for (var i = 0; i < input.Length; i++)
            {
                char c = input[i];
                char next = (i + 1) < input.Length ? input[i+1] : ' ';

                if(c == next)
                {
                    count++;
                    continue;
                }              
                else
                {
                    sb.Append($"{count}{c}");
                    count = 1;
                }
            }

            return sb.ToString();
        }
    }
}
