using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 計程車收費
{
    class Program
    {
        //仔細看資料 ((夜間時段不一樣))
        //來源格式盡量維持
        static void Main(string[] args)
        {
        Start:
            PriceList totMoney = new PriceList();
        inputLocal:
            Console.Write("請輸入縣市代號：");
            int Local = Convert.ToInt16(Console.ReadLine());
            if (Local < 0 || Local > 16)
            {
                Console.WriteLine("**縣市輸入錯誤**，請重新選擇。\n");
                goto inputLocal;
            }
            else
            {
                Local--;
            }

        inputTime:
            string Slot = "";
            Console.WriteLine("夜間乘車時段為 23:00 ~ 06:00");
            Console.WriteLine("請輸入搭乘時段(0.查看全天收費/1.早/ 2.晚)");
            int TimeSlot = Convert.ToInt16(Console.ReadLine());
            if (TimeSlot < 0 || TimeSlot > 2)
            {
                Console.WriteLine("**時段輸入錯誤**，請重新選擇。\n");
                goto inputTime;
            }
            else
            {
                if (TimeSlot == 1)
                    Slot = "*日間*搭乘";
                else
                    Slot = "*夜間*搭乘";
                TimeSlot--;
            }

            Console.Write("請輸入搭乘距離(KM)：");
            double Distance = Convert.ToDouble(Console.ReadLine());

            Console.Write("請輸入延遲時間(分鐘)：");
            double Deley = Convert.ToDouble(Console.ReadLine());

            Console.Write("是否查看價目表？(Y/n)：");
            if (Console.ReadLine().ToLower() == "n")
            {
                Console.Clear();
                totMoney.GetPrice(Local, Distance * 1000, Deley * 60, Slot, TimeSlot);
            }
            else
            {
                Console.Clear();
                totMoney.GetInfo(Local, TimeSlot);
                totMoney.GetPrice(Local, Distance * 1000, Deley * 60, Slot, TimeSlot);
            }

            Console.WriteLine("是否重新查詢？(Y/n)");
            string reset = Console.ReadLine();
            if (reset.ToLower() == "n") { }
            else
            {
                Console.Clear();
                goto Start;
            }

        }
    }
}
