using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace 判斷月份最後一天_2
{
    class Program
    {
        static void Main(string[] args)
        {
          
            WriteLine("請輸入月份");
            int Num = int.Parse(ReadLine());
            if (Num <= 12)
            {
                WriteLine($"本月底是 {DateTime.DaysInMonth(2019, Num)} 號");
            }
            else
            {
                WriteLine("別亂打");
            }

            Read();
        }
    }
}
