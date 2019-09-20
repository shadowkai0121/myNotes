using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static string signal = "☆";
        static void Main(string[] args)
        {
            int lines = howManyLines();

            ArrayList play = rndNums();
            printMap(play);

            gameLoop(play, lines);

            Console.WriteLine("BIIIIIIIIIIINGO！！");

        }

        // 判斷數字
        private static int isNum(string sNum)
        {
            int num = 0;
            int.TryParse(sNum, out num);
            return num;
        }

        // 輸入連線數量
        private static int howManyLines()
        {
            int lines = 0;

            while (lines == 0)
            {
                Console.Write("請輸入幾條連線賓果（<5）：");
                lines = isNum(Console.ReadLine());
                if (lines > 5)
                {
                    lines = 0;
                    Console.WriteLine("請確認數字無誤！");
                    continue;
                }
            }
            Console.Clear();
            return lines;
        }

        // 取得亂數陣列
        private static ArrayList rndNums()
        {
            Random rnd = new Random();
            List<int> nums = new List<int>(Enumerable.Range(1, 25));
            List<int> rndNums = nums.OrderBy(o => rnd.Next()).ToList();
            ArrayList map = new ArrayList();
            for (int i = 0; i < 25; i++)
            {
                map.Add(rndNums[i]);
            }
            return map;
        }

        // 顯示畫面
        private static void printMap(ArrayList play)
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                // 每列印出 5 個之後斷行
                for (int j = i * 5; j < 5 * (i + 1); j++)
                {
                    Console.Write($"\t{play[j]}");
                }
                Console.WriteLine("\r\n");
            }
        }

        // 遊戲開始
        private static void gameLoop(ArrayList play, int lines)
        {
            int num = 0;
            ArrayList usedNum = new ArrayList();
            int hasLines = 0;
            while (num == 0)
            {
                Console.WriteLine($"還差 {lines-hasLines} 條線");
                Console.Write("請輸入號碼：");
                num = isNum(Console.ReadLine());
                if (usedNum.IndexOf(num) != -1)
                {
                    num = 0;
                    Console.WriteLine("數字重複或不存在，請重新輸入。");
                    continue;
                }
                else
                {
                    usedNum.Add(num);
                }
                try
                {
                    play[play.IndexOf(num)] = signal;
                    hasLines = countLines(play);
                    printMap(play);
                    // 連線數達成了沒
                    if (hasLines >= lines)
                    {
                        break;
                    }
                }
                catch
                {
                    continue;
                }
                num = 0;
            }
        }

        // 判斷連線
        private static int countLines(ArrayList play)
        {
            // 判斷連線
            int lineCnt = 0;
            bool[] cntRepeat = new bool[12];
            int cnt = 0;
            // 左上右下
            for (int i = 0; i < 25; i += 6)
            {
                if (cntRepeat[0])
                {
                    lineCnt++;
                    break;
                }
                if (play[i].ToString() == signal)
                {
                    cnt++;
                    if (cnt == 5 && !cntRepeat[0])
                    {
                        cntRepeat[0] = true;
                        lineCnt++;
                        cnt = 0;
                    }
                }
            }

            // 右上左下
            cnt = 0;
            for (int i = 4; i < 21; i += 4)
            {
                if (cntRepeat[1])
                {
                    lineCnt++;
                    break;
                }
                if (play[i].ToString() == signal)
                {
                    cnt++;
                    if (cnt == 5 && !cntRepeat[1])
                    {
                        cntRepeat[1] = true;
                        lineCnt++;
                    }
                }
            }

            // 橫線
            for (int i = 0; i < 5; i++)
            {
                cnt = 0;
                if (cntRepeat[i + 2])
                {
                    lineCnt++;
                    continue;
                }
                for (int j = 5 * i; j < 5 * (i + 1); j++)
                {
                    if (play[j].ToString() == signal)
                    {
                        cnt++;
                        if (cnt == 5 && !cntRepeat[i + 2])
                        {
                            cntRepeat[i + 2] = true;
                            lineCnt++;
                        }
                    }
                }
            }

            //直線
            for (int i = 0; i < 5; i++)
            {
                cnt = 0;
                if (cntRepeat[i + 7])
                {
                    lineCnt++;
                    continue;
                }
                for (int j = i; j < (21 + i); j += 5)
                {
                    if (play[j].ToString() == signal)
                    {
                        cnt++;
                        if (cnt == 5 && !cntRepeat[i + 7])
                        {
                            cntRepeat[i + 7] = true;
                            lineCnt++;
                        }
                    }
                }
            }

            return lineCnt;
        }


    }
}
