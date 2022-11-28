using Day16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public static class ListExtensions
    {
        public static AuntInfo Nearby<AuntInfo>(this List<AuntInfo> list, AuntInfo value)
        {
            var helper = new List<(AuntInfo item, int value)>();

            //foreach (AuntInfo item in list)
            //{
            //    var score = item.GetScore(value);

            //    helper.Add((item, 5));
            //}

            return helper.First().item;
        }
    }
}