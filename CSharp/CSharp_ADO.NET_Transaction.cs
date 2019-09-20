using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace test0412_transaction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"server = .; database = northwind; integrated security = true;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (cn.State != ConnectionState.Open) { cn.Open(); }

            // 交換開始
            SqlTransaction t = cn.BeginTransaction(); //預設read committed;

            SqlCommand cmd = new SqlCommand
                (
                "UPDATE Products SET UnitsInStock =10 WHERE ProductID=1",
                cn,
                t //初始化隔離層級
                );

            // 送出指令
            cmd.ExecuteNonQuery();
            MessageBox.Show("Pause");

            // 取消交換
            t.Rollback();
            cn.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (cn.State != ConnectionState.Open) { cn.Open(); }

            SqlTransaction t = cn.BeginTransaction();

            #region 用try包覆傳送指令的過程
            // 一切正常則 Commit
            // 否則 RollBack;
            try
            {
                SqlCommand cmd = new SqlCommand
                ("UPDATE Products SET UnitsInStock =10 WHERE ProductID=1", cn, t);
                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch
            {
                t.Rollback();
            }
            #endregion
        }
    }
}
