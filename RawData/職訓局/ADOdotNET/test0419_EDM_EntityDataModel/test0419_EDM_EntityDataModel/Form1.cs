using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0419_EDM_EntityDataModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 來源能不能是database以外的東西? Excel? Web?
        // 把爬蟲程式改用實體資料模型再做一次
        // 要怎強迫db更新
        NorthwindEntities db = new NorthwindEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            // lazy loading 
            // 有資料從db物件參考抓、沒資料從server抓
            // 資料有增加時才會更新
            // 查詢中修改SQL資料庫實不會再次更新db物件參考上要資料 (快取)
            // 要多少給多少不會多給
            //var Q = from o in db.Customers
            //            //where o.CustomerID == "ALFKI"
            //        select o;

            //dataGridView1.DataSource = Q.ToList();

            using (NorthwindEntities db2 = new NorthwindEntities())
            {
                var Q = from o in db2.Customers
                            //where o.CustomerID == "ALFKI"
                        select o;

                dataGridView1.DataSource = Q.ToList();
            }
        }

        //新增資料
        private void button2_Click(object sender, EventArgs e)
        {
            Customer c = new Customer()
            {
                CustomerID = "00001",
                CompanyName = "Name 00001"
            };

            // 只會進到物件參考
            db.Customers.Add(c);
            // 傳回資料庫
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Q = from o in db.Customers
                    where o.CustomerID == "00001"
                    select o;

            Customer c = Q.SingleOrDefault();
            if (c != null)
            {
                // 多個client在同一個欄位修改上衝突??
                c.CompanyName = "0001 name ver:2";
                c.ContactName = "??????";
                MessageBox.Show("Test");
                db.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Q = from o in db.Customers
                    where o.CustomerID == "00001"
                    select o;

            Customer c = Q.SingleOrDefault();
            if (c != null)
            {
                db.Customers.Remove(c);
                db.SaveChanges();
            }
        }
    }
}
