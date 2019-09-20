using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace 回傳輸入月份的最後一天
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("請輸入月份");
            int Num = int.Parse(ReadLine());
            
            if (Num <= 12)
            {
                DateTime ThisMonth = new DateTime(2019, Num, 1);     //轉成日期
                DateTime EndDay = ThisMonth.AddMonths(1).AddDays(-1);//月份+1、日期-1
                WriteLine($"現在是 {Num} 月");
                WriteLine($"月底是： {EndDay.Day} 號");
            }
            else
            {
                WriteLine("別亂打");
            }
            

            Read();
        }
    }
}
