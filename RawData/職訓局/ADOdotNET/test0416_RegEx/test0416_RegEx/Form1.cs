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

namespace test0416_RegEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = " ...<ul>ooo</ul>xxx";
            Regex reg = new Regex("<ul>(.+?)</ul>");
            // .任意字元，+一個以上，?零或一個、尋找最近的
            Match result = reg.Match(html);
            // MessageBox.Show(result.ToString());
            // button1.Text = result.Success.ToString();//是否匹配成功
            button1.Text = result.Value;
            // 資料裡面有換行的時候需要加上RagexOptions.Singleline
            // string html = " ...<ul>\r\n###</ul>xxx";
            // Regex reg = new Regex("<ul>(.+?)</ul>", RagexOptions.Singleline);
            // 在比對成功之後形成單行回傳
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ?跟+的差別
            // +是GreedySearch
            // ?是LazySearch
            string hello = "Heello";
            //Regex reg = new Regex("H?l");      //l
            //Regex reg = new Regex("H(.+)l");   // Heell
            //一個以上字元盡量積極比對，到l就停下來
            //Regex reg = new Regex("H(.?)l");     // ""  he後面沒有l
            Regex reg = new Regex("H(.+?)l");  // Heel
            Match m = reg.Match(hello);
            //button2.Text = m.Success.ToString();
            button2.Text = m.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string hello = "CI-123";   //true
            //string hello = "xCI-123";  //true
            //string hello = "CI-1239";  //true
            //string hello = "CI-a123";  //false
            //Regex reg = new Regex(@"CI-\d{3}");

            // $ = END;
            //string hello = "CI-1239";  //false
            //Regex reg = new Regex(@"CI-\d{3}$");

            // ^ = Start;
            string hello = "xxxCI-123..."; //false
            Regex reg = new Regex(@"^CI-\d{3}$");

            // ^$ 驗證用
            // .+?擷取用
            button3.Text = reg.IsMatch(hello).ToString();
        }
    }
}
