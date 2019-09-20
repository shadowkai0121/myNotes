using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace test0415_抓取網頁
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 下載網頁
        // 下載頁面 
        // new WebClient & DownLoadFile("網址", "下載到...")
        // 讀取資料 
        // new StreamReader & ReadToEnd()
        // 使用正則運算擷取
        // using System.Text.RegularExpressions;
        // new Regex("比對型態, 指定模式");
        // 用XML讀取
        // doc = new XMLDocument
        // doc.LoadXML()
        // 寫到textbox
        // new XMLNodeList
        // foreach (XMLNode node in XMLNodeList)
        #endregion



        string web = "https://tw.appledaily.com/";
        private void button1_Click(object sender, EventArgs e)
        {
            // 下載頁面
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.DownloadFile(web, Application.StartupPath + @"\AppleDaily.txt");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader r = new StreamReader(Application.StartupPath + @"\AppleDaily.txt");
            string html = r.ReadToEnd();
            r.Close();
            //substring 取得<ul></ul>
            //textBox1.Text = html.Substring(html.IndexOf("mrt"), html.IndexOf("/aside") - html.IndexOf("mrt"));

            string StartWith = "<ul class=\"mrt\">";
            string EndWith = "</ul>";
            ExtratTarget(html, StartWith, EndWith);
        }

        #region 縮小尺度規模&建立function
        private void button3_Click(object sender, EventArgs e)
        {
            string html = "...<ul class=\"mrt\">OOO</ul>...";
            //             0123456789012 3456 78901234567890
            //                       1           2

            //目測抓區間
            //int Start = 3;
            //int End = 24;
            //textBox1.Text = html.Substring(Start, End);

            //開始代換
            //數字換成字串
            //int Start = html.IndexOf("<ul class=\"mrt\">"); //3
            //int End = html.IndexOf("</ul>"); //22
            //textBox1.Text =End.ToString();

            //字串換成變數
            //string EndWith = "</ul>";
            //int Start = html.IndexOf("<ul class=\"mrt\">"); //3
            //int End = html.IndexOf("</ul>", Start); //22
            //int length = End - Start + EndWith.Length;
            //textBox1.Text = length.ToString();

            //完成品
            //string StartWith = "<ul class=\"mrt\">";
            //string EndWith = "</ul>";
            //int Start = html.IndexOf(StartWith); //3
            //int End = html.IndexOf(EndWith, Start); //22
            //int length = End - Start + EndWith.Length;
            //textBox1.Text = html.Substring(Start,length);

            //淨化！
            string StartWith = "<ul class=\"mrt\">";
            string EndWith = "</ul>";
            ExtratTarget(html, StartWith, EndWith);
        }

        // 取出可重複使用的部分
        private void ExtratTarget(string html, string StartWith, string EndWith)
        {
            int Start = html.IndexOf(StartWith); //3
            int End = html.IndexOf(EndWith, Start); //22
            int length = End - Start + EndWith.Length;
            string ul = html.Substring(Start, length);
            //textBox1.Text = ul;

            // 以XML方式讀取
            ReadByXML(ul);
        }

        private void ReadByXML(string ul)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ul);
            XmlNodeList nodeList = doc.SelectNodes("/ul/li");
            foreach (XmlNode li in nodeList)
            {
                string text = li.SelectSingleNode("./a").InnerText;
                string href = li.SelectSingleNode("./a").Attributes["href"].Value;
                textBox1.Text += text + "\r\n" + web + href + Environment.NewLine;
                //textBox1.Text += "OK"+"\r\n";
            }
        }
        #endregion



        #region 正則運算
        private void button4_Click(object sender, EventArgs e)
        {
            // 載入資料
            StreamReader r = new StreamReader(@"C:\Users\admin\Desktop\ADOdotNET\data\AppleDaily.txt");
            string html = r.ReadToEnd();
            r.Close();
            // using System.Text.RegularExpressions;
            // 正則運算式 Regex("型態",RegexOptions.Singleline);
            // 比對型態如果吻合就擷取出來
            // .代表任意字元，+代表一個以上{1,}，?零或一個{0,1}
            // 
            Regex reg = new Regex("<ul class=\"mrt\">(.+?)</ul>", RegexOptions.Singleline);
            string ul = reg.Match(html).Value;
            //textBox1.Text = ul;
            ReadByXML(ul);
        }
        #endregion
    }
}
