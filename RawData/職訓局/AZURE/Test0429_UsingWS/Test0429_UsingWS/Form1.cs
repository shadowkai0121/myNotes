using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test0429_UsingWS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //myWebService1.Url=
            // 設定連線愈時
            myWebService1.Timeout = 1000;
            // 讓myWebService1能夠記住session
            myWebService1.CookieContainer = new System.Net.CookieContainer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = myWebService1.Add(3, 5).ToString();

            // 先委派動作
            myWebService1.AddCompleted += MyWebService1_AddCompleted ;
            myWebService1.AddAsync(3,5);
            button1.Text = "處理中...";
        }

        private void MyWebService1_AddCompleted(object sender, localhost.AddCompletedEventArgs e)
        {
            button1.Text = e.Result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = myWebService1.SaveData("b","Banana");
            this.Text = myWebService1.GetData("b");
        }
    }
}
