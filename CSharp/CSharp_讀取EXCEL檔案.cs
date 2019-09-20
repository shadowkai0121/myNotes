using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//===引用
using System.Data;
using System.Data.OleDb;
//===

namespace 讀取EXCEL檔案
{
    class Program
    {
        static void Main(string[] args)
        {

            //====抓EXCEL檔案===
            //OleDbConnection conn = new OleDbConnection(
            //    @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            //    "Data Source = " + filePath +
            //    ";Extended Properties='Excel 12.0;" +
            //    "HDR=YES;" +
            //    "IMEX=1'");
            //1.檔案路徑(需要雙\)
            //const string filePath = "C:\\Users\\admin\\Desktop\\職訓局\\C#\\計程車收費.xlsx";

            //指派相對路徑
            string tempFilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string filePath = tempFilePath.Substring(0, tempFilePath.IndexOf("讀取EXCEL檔案\\"))+ "\\讀取EXCEL檔案\\計程車收費.xlsx";
            //指派相對路徑

            //2.提供者名稱
            //Microsoft.Jet.OLEDB.4.0  適用於2003以前版本
            //Microsoft.ACE.OLEDB.12.0 適用於2007以後的版本處理
            const string ProvideName = "Microsoft.ACE.OLEDB.12.0;";

            //3.Excel版本
            //Excel 5.0 針對Excel97。
            //Excel 8.0 針對Excel2000及以上版本
            //Excel 12.0         2010?
            const string ExtendedString = "'Excel 12.0;";

            //4.第一行是否為標題
            const string Hdr = "YES;";

            //5.IMEX=0; 只能寫入
            //       1; 只能讀取
            //       2; 可以讀寫
            const string IMEX = "1';";

            //6.連線設定字串
            string conns =
               "Provider=" + ProvideName +
               "Data Source=" + filePath +
               ";Extended Properties=" + ExtendedString +
               "HDR=" + Hdr +
               "IMEX=" + IMEX;

            //7.連線
            OleDbConnection conn = new OleDbConnection(conns);
            //\===抓EXCEL檔案===

            DataTable dt = new DataTable();

            //查詢指令
            string tableName = "[Sheet1$]";
            string sql = "select * from " + tableName + "where 區域 = '台中'";//SQL查詢
            //string sql = Console.ReadLine();

            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            //\查詢指令
            da.Fill(dt);
            conn.Close();

            Console.WriteLine($"dataTable總行數 = {dt.Rows.Count}");
            Console.WriteLine($"dataTable.Select()[行數][欄位名稱] = {dt.Select()[0]["起跳金額"].ToString()}");
            //Console.WriteLine($"dataTablle.Rows[第幾個][欄位名稱]的資料 = {dt.Rows[3]["續跳里程"]}");
            //Console.WriteLine($"dataTable總欄數 = {dt.Columns.Count}");
            //Console.WriteLine($"dataTablle.Rows[第幾個][行名稱]的資料 = {dt.Columns[1]}");

            Console.ReadKey();
        }
    }
}
