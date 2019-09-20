using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While水仙花
{
    class Program
    {
        static void Main(string[] args)
        {
            //判斷 100 - 999 數字符合以下條件。
            //abc = (a * a * a) + (b * b * b) + (c * c * c)
            int i = 100;
            while (i <= 999)
            {
                int a = i / 100;
                int b = i % 100 / 10;
                int c = i % 10;

                int check = a * a * a + b * b * b + c * c * c;

                if (i == check)
                {
                    Console.WriteLine($"{i} = {a.ToString()}^3 + {b.ToString()}^3 + {c.ToString()}^3");
                }
                i++;
            }
            Console.ReadKey();
        }
    }
}
