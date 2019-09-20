using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace 停車費計算
{
    class Program
    {
        // 累進費率
        // < 30min $0;
        // 30 min ~ 1   hr    $20;
        // 1 hr   ~ 1.5 hr    $40;
        // 1.5hr  ~ 2   hr    $60;
        // pm 18:00 ~ 22:00   $60;
        // pm 22:00 ~ am 8:00 $ 0;

        static void Main(string[] args)
        {
            string Exit;
            do
            {
                WriteLine("請輸入進入時間(0~24)");
                string Start = ReadLine();
                string StartHour = "";
                string StartMin = "";

                WriteLine("請輸入離開時間(0~24)");
                string End = ReadLine();
                string EndHour = "";
                string EndMin = "";

                //切割時間
                //進場時間
                if (Start.Length > 3)
                {
                    StartHour = Start.Substring(0, 2);
                    StartMin = Start.Substring(2, 2);
                }
                else
                {
                    StartHour = Start.Substring(0, 1);
                    StartMin = Start.Substring(1, 2);
                }

                //離場時間
                if (End.Length > 3)
                {
                    EndHour = End.Substring(0, 2);
                    EndMin = End.Substring(2, 2);
                }
                else
                {
                    EndHour = End.Substring(0, 1);
                    EndMin = End.Substring(1, 2);
                }

                // 判斷時間
                int TotMin = (int.Parse(EndHour) - int.Parse(StartHour)) * 60 +
                    int.Parse(EndMin) + int.Parse(StartMin);
                //WriteLine(int.Parse(StartHour));
                //WriteLine(int.Parse(EndHour));
                //WriteLine($"TotMin => {TotMin}");
                double X = (TotMin - 1) / 30;
                int Tick = Convert.ToInt16(Math.Floor(X));
                //WriteLine($"Tick => {Tick}");
                int Tot = 0;

                // 計算總金額
                if (Tick < 1)
                {
                    Tot = 0;
                }
                else if (Tick < 4 && Tick >= 1)
                {
                    Tot = 20 * Tick;
                }
                else
                {
                    Tot = 20 * 3 + 30 * (Tick - 3);
                }
                WriteLine($"總金額 = ${Tot}");

                Exit = ReadLine().ToLower();//跳出迴圈
            } while (Exit != "end");
        }
    }
}
