using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 猜數字____完成
{
    class Program
    {
        static void Main(string[] args)
        {
            int Times = 0;
        Start:
            Console.WriteLine("你覺得你猜幾次猜的到?");
            try
            {
                Times = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("不要亂按！");
                goto Start;
            }

            Random Rnd = new Random();
            // 隨機數字
            ArrayList RndArr = new ArrayList();
            // 解答
            ArrayList NumArr = new ArrayList();
            int temp = 0;
            for (int i = 0; i < 10; i++)
            {
                RndArr.Add(i);
            }
            for (int i = 0, x = 9; i < 4; i++, x--)
            {
                temp = Rnd.Next(x);
                NumArr.Add(RndArr[temp]);
                RndArr[temp] = RndArr[x - 1];
            }

        //遊戲開始
        Input:
            while (Times != 0)
            {
                Console.Write("請輸入四位數字：");
                string Play = Console.ReadLine();
                int[] PlayArr = new int[4];
                try
                {
                    for (int i = 0; i < 4; i++)
                    {
                        PlayArr[i] = int.Parse(Play.Substring(i, 1));
                    }
                }
                catch 
                {
                    Console.WriteLine("不要亂按！");
                    goto Input;
                }


                int A = 0, B = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (NumArr.IndexOf(PlayArr[i]) == i)
                    {
                        A++;
                    }
                    else if (NumArr.IndexOf(PlayArr[i]) != -1)
                    {
                        B++;
                    }
                }
                if (A == 4)
                {
                    Console.WriteLine("恭喜答對了!!");
                    goto Start;
                }
                else
                {
                    Times--;
                    Console.WriteLine($"{Play} 錯! {A} A {B} B");
                    Console.WriteLine($"顆顆，你還剩下 {Times} 次機會");
                    goto Input;
                }
            };
            Console.Write("正確答案是：");
            foreach (var item in NumArr)
            {
                Console.Write($"{item}");
            }
            Console.WriteLine("\n次數超過了，再去練練吧！");
            goto Start;
        }
    }
}
