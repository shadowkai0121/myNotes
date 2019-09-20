using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    class Program
    {
        static void SetDictionary(string[,] NightHour, int pos, string inputTime)
        {
            int end = int.Parse(NightHour[pos, 0].Replaced(":", ""));
            int start = int.Parse(NightHour[pos, 1].Replaced(":", ""));
        }
        static void Main(string[] args)
        {
            Dictionary<int, int> dc = new Dictionary<int, int>();
            if (inputCity != 0)
            {

            }
            else
            {
                SetDictionary(NightHour, int, inputTime, dc);
            }
        }
    }
}
