using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 整理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 建立EDM物件並且在查詢完之後釋放
            using (NorthwindEntities db = new NorthwindEntities())
            {
                // LINQ查詢語法
                var Q = from o in db.Customers
                        select o;

                dataGridView1.DataSource = Q.ToList();
            }
        }// btnQuery

        NorthwindEntities ndb = new NorthwindEntities();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // LINQ查詢語法
            var Q = from o in ndb.Customers
                    where o.CustomerID == "00001"
                    select o;

            // 將查詢結果指定給物件
            Customer c = Q.SingleOrDefault();
            if (c != null)
            {
                //設定物件資料
                c.CompanyName = "Name 00001 Changed";
                c.ContactName = "??????";
                // 傳回資料庫
                ndb.SaveChanges();
            }
            dataGridView1.DataSource = Q.ToList();
        }// btnUpdate

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // 設定資料
            Customer c = new Customer();
            c.CustomerID = "00001";
            c.CompanyName = "Name 00001";

            // 新增至EDM
            ndb.Customers.Add(c);

            // 上傳回資料庫
            ndb.SaveChanges();
        }// btnInsert

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // LINQ查詢語法
            var Q = from o in ndb.Customers
                    where o.CustomerID == "00001"
                    select o;

            // 將查詢結果指定給物件
            Customer c = Q.SingleOrDefault();

            if (c!= null)
            {
                // 刪除資料
                ndb.Customers.Remove(c);

                // 傳回資料庫
                ndb.SaveChanges();
            }
        }// btnRemove

    }// form
}//namespace
