using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public class NumberUtils
    {
        public static int RandomReferenceNo(string value)
        {
            int maxValue = 9999999;
            int minValue = 0;
            Random random = new Random();
            if (!string.IsNullOrEmpty(value)) minValue = int.Parse(value);
            return random.Next(minValue, maxValue);
        }
    }
}
