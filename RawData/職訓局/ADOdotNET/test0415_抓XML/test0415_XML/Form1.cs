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

namespace test0415_XML
{
    // 抓外語各大報頭條 翻譯成中文跑馬燈集中管理
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        #region 下載XML檔案
        private void button1_Click(object sender, EventArgs e)
        {
            // HttpClient 比較常用
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.DownloadFile("https://www.cnbc.com/id/100003114/device/rss/rss.html",
            @"C:\Users\admin\Desktop\ADOdotNET\data\news.xml");
            //wc.DownloadFile("https://www.macromicro.me/blog", @"C:\Users\admin\Desktop\ADOdotNET\data\test.xml");
            button1.Text = "OK";
        }
        #endregion //下載XML檔案



        #region 爬取離線XML內容
        // 流程
        // 宣告XML物件
        // XML物件.Loat(完整路徑);
        // 宣告XMLNodeList物件 = XML物件.SelectNodes(節點的相對路徑);
        // foreach宣告XMLNodeList中的XMLNode物件
        // 用InnerText印出XMLNode物件
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\admin\Desktop\ADOdotNET\data\news.xml");

            XmlNode title = doc.SelectSingleNode("/rss/channel/title");
            // 判斷元素是否存在
            if (title == null)
            {
                button2.Text = "Title not found";
                return;
            }
            // 讀取node內容用InnerText
            //button2.Text = title.InnerText;
            XmlNodeList itemList = doc.SelectNodes("/rss/channel/item");
            // 要用單項 XmlNode
            foreach (XmlNode item in itemList)
            {
                // 在txtShow上顯示
                txtShow.Items.Add(item.SelectSingleNode("./title").InnerText);
            }

            // 如何讀取RSS的屬性值
            XmlNode RssVersion = doc.SelectSingleNode("/rss");
            // button2.Text = RssVersion.Attributes[0].Value;
            // this.Text顯示在視窗標題
            this.Text = RssVersion.Attributes["version"].Value;
        }
        #endregion //爬取離線XML內容
    }
}
