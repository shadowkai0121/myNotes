using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace 判斷是否為倍數
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 讓使用者輸入兩個數字，判斷第二個數字是不是第一個數字的倍數
            WriteLine("輸入第一個數字");
            float a = float.Parse(ReadLine());
            WriteLine("輸入第二個數字");
            float b = float.Parse(ReadLine());

            //判斷餘數
            float Remainder1 = b % a;
            float Remainder2 = a % b;

            if ( Remainder1 == 0 || Remainder2 == 0)
            {
                WriteLine($"{a} 跟 {b} 有關係!!");
            }
            else
            {
                WriteLine($"他們不是倍數~~~他們不是倍數~~~");
            }
            Read();
        }
    }
}
