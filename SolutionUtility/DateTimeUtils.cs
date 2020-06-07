using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUtility
{
    public class DateTimeUtils
    {
        public static string ConvertToDate6(DateTime dateTime)
        {
            return dateTime.ToString("ddMMyy");
        }

        public static string ConvertToJulian(DateTime dateTime)
        {
            return string.Format("{0:yyyy}{1:D3}", dateTime, dateTime.DayOfYear);
        }
    }
}
