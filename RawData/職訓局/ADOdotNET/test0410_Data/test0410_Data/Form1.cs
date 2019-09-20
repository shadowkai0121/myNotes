using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0410_Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void sqlDataAdapter2_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {

        }

        //按下BUTTON1取得資料
        private void GetData(object sender, EventArgs e)
        {
            sqlDataAdapter2.Fill(northWindDataSet1);
        }

        //按下BUTTON2上傳資料
        private void button2_Click(object sender, EventArgs e)
        {
            sqlDataAdapter2.Update(northWindDataSet1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            northWindDataSet1.WriteXml(@"C:\Users\admin\Desktop\ADOdotNET\nw.xml",
                XmlWriteMode.DiffGram);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            northWindDataSet1.ReadXml(@"C:\Users\admin\Desktop\ADOdotNET\nw.xml");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = bindingSource1.Position;
            textBox1.Text =
                northWindDataSet1.Products[i].ProductName;
        }


        private void followUSER(object sender, EventArgs e)
        {
            //沒有內容時不採取行動。
            if (northWindDataSet1.Products.Count <= 0)
            {
                return;
            }
            int i = bindingSource1.Position;
            textBox1.Text =
                northWindDataSet1.Products[i].ProductName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //根據資料表造橫列
            var p =
                northWindDataSet1.Products.NewProductsRow();
            //定義新的值
            p.ProductID = 999;//不會被採用
            p.ProductName = "test 1";
            p.Discontinued = false;

            //把值丟回去
            northWindDataSet1.Products.AddProductsRow(p);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var p =
                northWindDataSet1.Products.FindByProductID(80);
            if (p == null)
            {
                return;
            }
            MessageBox.Show(p.RowState.ToString());
            p.Delete(); //刪除物件
            MessageBox.Show(p.RowState.ToString());
        }
    }
}
