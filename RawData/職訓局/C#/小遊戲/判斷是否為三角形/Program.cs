using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace 判斷
{
    class Program
    {
        static void Main(string[] args)
        {

            WriteLine("輸入第一個邊");
            float a = float.Parse(ReadLine());
            WriteLine("輸入第二個邊");
            float b = float.Parse(ReadLine());
            WriteLine("輸入第三個邊");
            float c = float.Parse(ReadLine());            

            WriteLine("===============");
            float I = (float)Math.Pow(a, 2);
            float O = (float)Math.Pow(b, 2);
            float P = (float)Math.Pow(c, 2);

            string Q = I.ToString("#0.000");
            string W = O.ToString("#0.000");
            string E = P.ToString("#0.000");

            float J = float.Parse(Q);
            float K = float.Parse(W);
            float L = float.Parse(E);

            //餘弦定理 cosA = ( b^2 + c^2 - a^2) / ( 2 a b)
            //cos 0deg =1
            //cos 90deg = 0;
            //cos 180deg = -1;
            //鈍角cos < 0

            if (a + b > c && a + c > b && b + c > a)
            {
                float CosA = (K + L - J) / (2 * b * c);
                float CosB = (J + L - K) / (2 * a * c);
                float CosC = (K + J - L) / (2 * c * b);

                WriteLine($"三角形 {a}, {b}, {c}");
                WriteLine($"cos() = {CosA}, {CosB}, {CosC}");

                if (a == b && b == c && c == a)
                {
                    WriteLine("正三角形");
                }

                if (CosA < 0 || CosB < 0 || CosC < 0)
                {
                    if (CosA == CosB || CosB == CosC || CosC == CosA)
                    {
                        WriteLine("等腰鈍角三角形");
                    }
                    else
                    {
                        WriteLine("鈍角三角形");
                    }
                }

                if (CosA > 0 && CosC > 0 && CosC > 0)
                {
                    if ((CosA == CosB) || (CosB == CosC) || (CosC == CosA))
                    {
                        WriteLine("等腰銳角三角形");
                    }
                    else
                    {
                        WriteLine("銳角三角形");
                    }
                }

                if (J + K == L || K + L == J || L + J == K)
                {
                    if ((CosA == CosB) || (CosB == CosC) || (CosC == CosA))
                    {
                        WriteLine("等腰直角三角形");
                    }
                    else
                    {
                        WriteLine("直角三角形");
                    }
                }

            }
            else
            {
                WriteLine($"{a}, {b}, {c}\n" +
                    $"非三角形");
            }
            Read();
        }
    }
}
