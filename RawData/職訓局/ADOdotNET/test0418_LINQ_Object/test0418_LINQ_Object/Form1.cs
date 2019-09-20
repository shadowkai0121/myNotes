using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace test0418_LINQ_Object
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // LINQ只有查詢功能
        // LINQ_Object
        private void button1_Click(object sender, EventArgs e)
        {
            string[] dataList = new string[] { "a1", "b", "a", "a3", "cb" };
            // select & where

            // select * from dataList;
            //var Q = from o in dataList select o;

            // select * from dataList where o裡面的開頭為a的元素
            var Q = from o in dataList where o.IndexOf("a") == 0 select o;
            // Q 是類別根據語法造物件然後產生功能
            MessageBox.Show(Q.GetType().ToString());
            //foreach (var data in Q)
            //{
            //    MessageBox.Show(data); // a1, a, a3
            //}

            // 程式內先查好資料再放出去
            var Qresult = Q.ToList();
            foreach (var data in Q)
            {
                MessageBox.Show(data); // a1, a, a3
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] dataList = new string[] { "a1", "b", "a", "a3", "cb" };
            // 字串比對
            // String.compare(str s1, str s2) → s1 - s2 → -1, 0, 1;
            // if (s1 > s2) // syntax error
            // if (String.Compare(s1, s2) > 0)

            // if (s1 == s2), if (s1 != s2) // ok

            // orderby
            var Q = from o in dataList
                        //orderby o ascending // == orderby o
                    orderby o descending
                    select o;

            foreach (var data in Q)
            {
                MessageBox.Show(data); // cb, b, a3, a1, a
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] dataList = new string[] { "a1", "b", "a", "a3", "cb" };

            var Q = from o in dataList where o == "a1" select o;

            foreach (var data in Q)
            {
                MessageBox.Show(data); // a1
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] dataList = new string[] { "a1", "b", "a", "a3", "cb" };

            //var Q = from o in dataList where o == "a1" select o;
            var Q = from o in dataList where FindDataInString(o, "a1") select o;

            foreach (var data in Q)
            {
                MessageBox.Show(data); // a1
            }

            bool FindDataInString(string source, string target)
            {
                return source.IndexOf(target) == 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] dataList = new string[] { "a1", "b", "a31x", "a2", "c" };
            // a後面有0個以上的數字結尾
            Regex reg = new Regex(@"^a[0-9]*$");

            // where data.Contains("a")
            var Q = from o in dataList
                    where reg.IsMatch(o)
                    orderby o descending
                    select o;

            foreach (var item in Q)
            {
                MessageBox.Show(item); // a2, a1
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Projection

            string[] dataList = new string[] { "a1", "b", "a31x", "a2", "c" };

            var Q = from o in dataList
                    where o.IndexOf("a") == 0
                    orderby o descending
                    select o.ToUpper();

            foreach (var item in Q)
            {
                MessageBox.Show(item); // A1, A31X, A2,
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 造新物件
            // 將資料處理成適合看的樣子
            string[] dataList = new string[] { "a1", "b", "a2", "c" };

            var query = from data in dataList
                        where data.IndexOf("a") >= 0
                        orderby data descending
                        select new {
                            original = data,
                            upperVer = data.ToUpper() };

            foreach (var item in query)
            {
                MessageBox.Show($"orginal = {item.original}, upperVer = {item.upperVer}");
            }
        }
        
        //var

    }
}
