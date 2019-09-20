using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HtmlAgilityPack;

namespace test0422_HtmlAgility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // using HtmlAgilityPack;
        private void button1_Click(object sender, EventArgs e)
        {
            // HtmlWeb
            // HtmlDocument
            // HtmlNode

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://tw.appledaily.com/");
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//*[@id=\"realtimenews\"]/aside/ul/li");
            foreach (HtmlNode node in nodes)
            {
                string line = string.Format(
                    $"{node.SelectSingleNode("./time").InnerText}\t" +
                    $"{node.SelectSingleNode("./a").InnerText}\t" +
                    $"{node.SelectSingleNode("./a").Attributes["href"].Value}\t"
                    );
                textBox1.Text += line + "\r\n";
            }

            button1.Text = "ok";
        }
    }
}
