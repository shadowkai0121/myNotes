using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace 計程車收費
{
    class PriceList
    {
        public string[] Local = new string[16];
        int[,,] PriLis = new int[2, 4, 16];
        public PriceList()
        {

            string tempFilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string filePath = tempFilePath.Substring(0, tempFilePath.IndexOf("計程車收費")) + "\\計程車收費.xlsx";

            const string ProvideName = "Microsoft.ACE.OLEDB.12.0;";
            const string ExtendedString = "'Excel 12.0;";
            const string Hdr = "YES;";
            const string IMEX = "1';";

            string conns =
               "Provider=" + ProvideName +
               "Data Source=" + filePath +
               ";Extended Properties=" + ExtendedString +
               "HDR=" + Hdr +
               "IMEX=" + IMEX;

            DataTable dtD = new DataTable();
            DataTable dtN = new DataTable();
            OleDbConnection conn = new OleDbConnection(conns);

            string tableNameD = "[Sheet1$]";
            string sqlD = "select * from " + tableNameD;
            OleDbDataAdapter daD = new OleDbDataAdapter(sqlD, conn);
            daD.Fill(dtD);

            string tableNameN = "[Sheet2$]";
            string sqlN = "select * from " + tableNameN;
            OleDbDataAdapter daN = new OleDbDataAdapter(sqlN, conn);
            daN.Fill(dtN);
            conn.Close();

            for (int i = 0; i < 16; i++)
            {
                Local[i] = Convert.ToString(dtD.Rows[i]["區域"]);
                PriLis[0, 0, i] = Convert.ToInt16(dtD.Rows[i]["起跳里程"]);
                PriLis[0, 1, i] = Convert.ToInt16(dtD.Rows[i]["起跳金額"]);
                PriLis[0, 2, i] = Convert.ToInt16(dtD.Rows[i]["續跳里程"]);
                PriLis[0, 3, i] = Convert.ToInt16(dtD.Rows[i]["延滯計費基準"]);

                PriLis[1, 0, i] = Convert.ToInt16(dtN.Rows[i]["起跳里程"]);
                PriLis[1, 1, i] = Convert.ToInt16(dtN.Rows[i]["起跳金額"]);
                PriLis[1, 2, i] = Convert.ToInt16(dtN.Rows[i]["續跳里程"]);
                PriLis[1, 3, i] = Convert.ToInt16(dtN.Rows[i]["延滯計費基準"]);
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4 * i; j < 4 * (i + 1); j++)
                {
                    Console.Write($"{(j + 1).ToString().PadLeft(2, '0')}、{Local[j]}\t");
                }
                Console.Write("\n");
            }
            Console.WriteLine("00、選擇全部縣市");
        }
        ~PriceList()
        {
            Console.WriteLine("Bye");
        }

        public void GetInfo(int LocalNum, int TimeSlot)
        {
            Console.WriteLine("\n區域\t\t起跳里程(m)\t起跳金額(元)\t續跳里程(m)\t延滯計費基準(sec)");
            if (LocalNum >= 0)
            {
                if (TimeSlot > 0)
                {
                    Console.Write($"{Local[LocalNum]}\t\t");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"{PriLis[TimeSlot, j, LocalNum]}\t\t");
                    }
                    Console.Write("\n");
                }
                else
                {
                    Console.Write($"日間收費\n");
                    Console.Write($"{Local[LocalNum]}\t\t");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"{PriLis[0, j, LocalNum]}\t\t");
                    }
                    Console.Write("\n");
                    Console.Write($"夜間收費\n");
                    Console.Write($"{Local[LocalNum]}\t\t");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"{PriLis[1, j, LocalNum]}\t\t");
                    }
                    Console.Write("\n");
                }

            }
            else
            {
                Console.Write("\n日間時段\n");
                for (int i = 0; i < 16; i++)
                {
                    Console.Write($"{Local[i]}\t\t");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"{PriLis[0, j, i]}\t\t");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n夜間時段\n");
                for (int i = 0; i < 16; i++)
                {
                    Console.Write($"{Local[i]}\t\t");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"{PriLis[1, j, i]}\t\t");
                    }
                    Console.Write("\n");
                }
            }
        }


        public void GetPrice(int LocalNum, double Distance, double DeleyTime, string Slot, int TimeSlot)
        {
            ArrayList DistMoneyD = new ArrayList();
            ArrayList DeleyMoneyD = new ArrayList();
            ArrayList TotalD = new ArrayList();

            ArrayList DistMoneyN = new ArrayList();
            ArrayList DeleyMoneyN = new ArrayList();
            ArrayList TotalN = new ArrayList();

            if (LocalNum >= 0)
            {
                if (TimeSlot > 0)
                {

                    if (Distance >= PriLis[TimeSlot, 0, LocalNum])
                    {
                        DistMoneyD.Add(Convert.ToInt16(Math.Round(PriLis[TimeSlot, 1, LocalNum] + ((Distance - PriLis[TimeSlot, 0, LocalNum]) / PriLis[TimeSlot, 2, LocalNum]) * 5, 0)));
                    }
                    else
                    {
                        DistMoneyD.Add(Convert.ToInt16(PriLis[TimeSlot, 1, LocalNum]));
                    }


                    DeleyMoneyD.Add(Convert.ToInt16(Math.Round((DeleyTime / PriLis[TimeSlot, 3, LocalNum]) * 5, 0)));
                    TotalD.Add(Convert.ToInt16(DistMoneyD[0]) + Convert.ToInt16(DeleyMoneyD[0]));
                    Console.WriteLine($"\n在 {Local[LocalNum]} {Slot} {Distance / 1000} 公里的計程車，路上延遲 {DeleyTime / 60} 分鐘。");
                    Console.WriteLine($"總金額是 * {TotalD[0]} * 元。");
                }
                else
                {
                    if (Distance >= PriLis[0, 0, LocalNum])
                    {
                        DistMoneyD.Add(Convert.ToInt16(Math.Round(PriLis[0, 1, LocalNum] + ((Distance - PriLis[0, 0, LocalNum]) / PriLis[0, 2, LocalNum]) * 5, 0)));
                    }
                    else
                    {
                        DistMoneyD.Add(Convert.ToInt16(PriLis[0, 1, LocalNum]));
                    }

                    DeleyMoneyD.Add(Convert.ToInt16(Math.Round((DeleyTime / PriLis[0, 3, LocalNum]) * 5, 0)));
                    TotalD.Add(Convert.ToInt16(DistMoneyD[0]) + Convert.ToInt16(DeleyMoneyD[0]));

                    if (Distance >= PriLis[1, 0, LocalNum])
                    {
                        DistMoneyN.Add(Convert.ToInt16(Math.Round(PriLis[1, 1, LocalNum] + ((Distance - PriLis[1, 0, LocalNum]) / PriLis[1, 2, LocalNum]) * 5, 0)));
                    }
                    else
                    {
                        DistMoneyN.Add(Convert.ToInt16(PriLis[1, 1, LocalNum]));
                    }

                    DeleyMoneyN.Add(Convert.ToInt16(Math.Round((DeleyTime / PriLis[1, 3, LocalNum]) * 5, 0)));
                    TotalN.Add(Convert.ToInt16(DistMoneyN[0]) + Convert.ToInt16(DeleyMoneyN[0]));

                    Console.WriteLine($"\n在 {Local[LocalNum]} {Distance / 1000} 公里的計程車，路上延遲 {DeleyTime / 60} 分鐘。");
                    Console.WriteLine($"*日間*搭乘總金額是 * {TotalD[0]} * 元。");
                    Console.WriteLine($"*夜間*搭乘總金額是 * {TotalN[0]} * 元。");
                }

            }
            else
            {
                LocalNum++;
                if (TimeSlot > 0)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (Distance >= PriLis[TimeSlot, 0, LocalNum])
                        {
                            DistMoneyD.Add(Convert.ToInt16(Math.Round(PriLis[TimeSlot, 1, i] + ((Distance - PriLis[TimeSlot, 0, i]) / PriLis[TimeSlot, 2, i]) * 5, 0)));
                        }
                        else
                        {
                            DistMoneyD.Add(Convert.ToInt16(PriLis[TimeSlot, 1, i]));
                        }

                        DeleyMoneyD.Add(Convert.ToInt16(Math.Round((DeleyTime / PriLis[TimeSlot, 3, i]) * 5, 0)));
                        TotalD.Add(Convert.ToInt16(DistMoneyD[i]) + Convert.ToInt16(DeleyMoneyD[i]));

                        Console.WriteLine($"\n{Slot} {Distance / 1000} 公里的計程車，路上延遲 {DeleyTime / 60} 分鐘。");
                        Console.WriteLine($"在 {Local[i]} 總金額是 * {TotalD[i]} *元");
                    }
                }
                else
                {
                    Console.WriteLine($"\n搭乘 {Distance / 1000} 公里的計程車，路上延遲 {DeleyTime / 60} 分鐘。");
                    Console.WriteLine("區域\t\t白天收費\t\t晚上收費");
                    for (int i = 0; i < 16; i++)
                    {
                        if (Distance >= PriLis[0, 0, i])
                        {
                            DistMoneyD.Add(Convert.ToInt16(Math.Round(PriLis[0, 1, i] + ((Distance - PriLis[0, 0, i]) / PriLis[0, 2, i]) * 5, 0)));
                        }
                        else
                        {
                            DistMoneyD.Add(Convert.ToInt16(PriLis[0, 1, i]));
                        }

                        DeleyMoneyD.Add(Convert.ToInt16(Math.Round((DeleyTime / PriLis[0, 3, i]) * 5, 0)));
                        TotalD.Add(Convert.ToInt16(DistMoneyD[i]) + Convert.ToInt16(DeleyMoneyD[i]));

                        if (Distance >= PriLis[1, 0, i])
                        {
                            DistMoneyN.Add(Convert.ToInt16(Math.Round(PriLis[1, 1, i] + ((Distance - PriLis[1, 0, i]) / PriLis[1, 2, i]) * 5, 0)));
                        }
                        else
                        {
                            DistMoneyN.Add(Convert.ToInt16(PriLis[1, 1, i]));
                        }

                        DeleyMoneyN.Add(Convert.ToInt16(Math.Round((DeleyTime / PriLis[1, 3, i]) * 5, 0)));
                        TotalN.Add(Convert.ToInt16(DistMoneyN[i]) + Convert.ToInt16(DeleyMoneyN[i]));

                        Console.Write($"{Local[i]}\t\t{TotalD[i]}\t\t\t{TotalN[i]}\n");
                    }
                    Console.Write("\n");
                }

            }

        }
    }
}
