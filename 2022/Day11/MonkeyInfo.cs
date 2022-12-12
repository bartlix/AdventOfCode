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
            Items = new List<long>();
        }
        public int Id { get; set; }

        public List<long> Items { get; set; }

        public int Divisor { get; set; }

        public int TrueId { get; set; }

        public int FalseId { get; set; }

        public string Operation { get; set; }
        
        public long InspectCount { get; set; }

        public long GetWorryLevel(long value)
        {
            var help = Operation.Replace("old", value.ToString());

            var parts = help.Split(' ');

            var a = long.Parse(parts[0]);
            var b = long.Parse(parts[2]);

            long result = 0;

            switch (parts[1])
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;

            }

            return result;
        }
    }
}
