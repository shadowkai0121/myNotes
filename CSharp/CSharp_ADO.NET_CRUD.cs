using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test0412_Command
{
    #region 1.執行Update
    // 開啟連線
    // 設置命令物件 SqlCommand 名稱 = new SqlCommand("TSQL指令", 連線物件);
    // 方法值型
    // 關閉
    #endregion

    #region 2.DataReader
    // 開啟連線
    // 設置命令物件
    // 設置SqlDataReader = 命令物件
    // 迴圈執行dr.read() & listbox.items.Add(reader["欄位名稱"]);
    // 結束連線
    #endregion

    #region 3.使用者輸入值查詢範圍資料
    // 開啟連線
    // 建立命令物件
    // 接收命令參數
    // 設定參數限制 (cmd.Parameters
    // 讀寫資料
    #endregion

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //連線字串應該放在設定中給網管使用");
        SqlConnection cn = new SqlConnection(@"server = .; database = NorthWind; Integrated Security = true;");
        #region 執行Update
        private void button1_Click(object sender, EventArgs e)
        {
            //如果沒連線就開始連線
            if (cn.State != ConnectionState.Open) { cn.Open(); }

            SqlCommand cmd = new SqlCommand("UPDATE Products SET UnitsInStock =50 WHERE ProductID=1", cn);
            cmd.ExecuteNonQuery(); //除了會傳回結果以外的都是NonQuerry; 

            //SQL物件查詢完就close
            //close並非完全斷線只是空出來給其他的連線物件使用
            //預設兩分鐘沒使用就會關掉(dotNET 內部設計)
            cn.Close();
        }
        #endregion \執行Update

        #region DataReader 讀取資料
        private void button2_Click(object sender, EventArgs e)
        {
            if (cn.State != ConnectionState.Open) { cn.Open(); }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Products p;", cn);

            // DataSet    會占用記憶體
            // DataReader 一次只記住一筆資料 #節省記憶
            SqlDataReader dr = cmd.ExecuteReader(); //集合物件
            while (dr.Read()) //while() 判斷式會被呼叫
            { listBox1.Items.Add(dr["ProductName"]); }

            cn.Close();
        }
        #endregion \DataReader 讀取資料

        #region 使用者輸入查詢值 (危險寫法、會被injection)
        private void button3_Click(object sender, EventArgs e)
        {
            if (cn.State != ConnectionState.Open) { cn.Open(); }

            // SQL Injection 資料放入程式碼
            // 字串內容含指令會讓SERVER去執行
            // 10~12月成功機率高(新鮮的肝)

            // ;UPDATE Products SET UnitsInStock = 30 WHERE ProductID = 1
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE UnitPrice >={textBox1.Text};", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { listBox1.Items.Add(dr["ProductName"]); }
        }
        #endregion \使用者輸入查詢值 (危險寫法、會被injection)

        #region 使用者輸入查詢值 (安全寫法)
        private void button4_Click(object sender, EventArgs e)
        {
            if (cn.State != ConnectionState.Open) { cn.Open(); }
            // 讓SELECT變成整體
            // @x 變數寫法
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE UnitPrice >=@x;", cn);
            //cmd.Parameters.Add();

            // 限制參數型態
            SqlParameter p = new SqlParameter("@x", SqlDbType.Money);
            //cmd.Parameters.Add(p);

            // 用受限制過的型態接收輸入值
            cmd.Parameters["@x"].Value = textBox1.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { listBox1.Items.Add(dr["ProductName"]); }
            cn.Close();
        }
        #endregion \使用者輸入查詢值 (安全寫法)
    }
}
