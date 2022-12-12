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
            Items = new List<int>();
        }
        public int Id { get; set; }

        public List<int> Items { get; set; }

        public int Divisor { get; set; }

        public int TrueId { get; set; }

        public int FalseId { get; set; }

        public string Operation { get; set; }
        
        public int InspectCount { get; set; }

        public int GetWorryLevel(int value)
        {
            var help = Operation.Replace("old", value.ToString());

            var result = Convert.ToInt32(new DataTable().Compute(help, null));

            return result;
        }
    }
}
