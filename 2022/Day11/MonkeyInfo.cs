using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class MonkeyInfo
    {
        public MonkeyInfo()
        {
            Items = new List<ulong>();
        }
        public int Id { get; set; }

        public List<ulong> Items { get; set; }

        public ulong Divisor { get; set; }

        public int TrueId { get; set; }

        public int FalseId { get; set; }

        public string Operation { get; set; }
        
        public ulong InspectCount { get; set; }

        public ulong GetWorryLevel(ulong value)
        {
            var help = Operation.Replace("old", value.ToString());

            var parts = help.Split(' ');

            var a = ulong.Parse(parts[0]);
            var b = ulong.Parse(parts[2]);

            ulong result = 0;

            switch (parts[1])
            {
                case "+":
                    result = a + b;
                    break;
                case "*":
                    result = a * b;
                    break;                

            }

            return result;
        }
    }
}
