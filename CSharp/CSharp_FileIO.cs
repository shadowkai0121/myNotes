using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;

namespace test0419_IO_input_output
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path = Application.StartupPath;
        private void button1_Click(object sender, EventArgs e)
        {
            string s = "ABC中文字";

            FileStream fs = new FileStream(path + @"/test.txt", FileMode.Create);

            //byte[] buffer = Encoding.ASCII.GetBytes(s); // ASCII不能解讀中文

            ////byte order mark 在檔案或串流的開頭處用特殊記號表示檔案類型
            //byte[] buffer = Encoding.Unicode.GetBytes(s);
            //// 255 254變成檔案的一部分不是內容的一部份(控制碼)
            //// (12 + 2 byte)
            //fs.WriteByte(255); fs.WriteByte(254);
            //fs.Write(buffer, 0, buffer.Length);
            //// 造成英文byte數上升 

            // UTF-8 英文 1 byte 中文 3 byte
            // 1 * 3 + 3 * 3 = 12
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            fs.Write(buffer, 0, buffer.Length);

            fs.Close();
            button1.Text = "ok";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(path + @"/test.txt", FileMode.Open);

            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);



            fs.Close();

            Encoding.UTF8.GetString(buffer);
            //textBox1.Text = buffer.ToString();
            textBox1.Text = Encoding.UTF8.GetString(buffer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // big5         123456789012
            // UTF-8        0 1 2 345678
            string line1 = "洋基隊   NYY";
            string line2 = "釀酒人隊 MIL";
            line2.Substring(6, 3);

            // JSON
            // { "cName": "洋基隊", "teamKey": "NYY" }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path + @"/test2.txt"))
            {
                sw.WriteLine("Line 1");
                sw.WriteLine("Line 2");
                sw.WriteLine("Line 3");
            }
            button4.Text = "ok";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(path + @"/test2.txt"))
            {
                //string line = sr.ReadLine();
                //while (line != null)
                //while (!string.IsNullOrEmpty(line))
                //{
                //    textBox1.Text += line + "\r\n";
                //    line = sr.ReadLine();
                //}
                // 遇到使用者空行會出錯

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    textBox1.Text += line + "\r\n";
                    //line = sr.ReadLine();
                    //textBox1.Text += line + "\r\n";
                }

            }

            button5.Text = "ok";
        }
    }
}
