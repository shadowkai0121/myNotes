using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace for計算階層
{
    class Program
    {
        static void Main(string[] args)
        {
            //輸入5，得到 5 * 4 * 3 * 2 * 1 = 120
            WriteLine("請輸入整數");
            int Num = int.Parse(ReadLine());
            int cnt = 1;
            string Result = "";

            for (int i = Num; i >= 1; i--)
            {
                cnt *= i;
                Result = Result + i.ToString() + "*";
            }
            
            WriteLine(Result.TrimEnd('*')+" = "+cnt);
            Read();
        }
    }
}
