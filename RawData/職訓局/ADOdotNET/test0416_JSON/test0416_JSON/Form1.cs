using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace test0416_JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TLoaction obj = new TLoaction() { x = 100, y = 100, Name = "TC" };
            string s = JsonConvert.SerializeObject(obj); // 物件序列化
            textBox1.Text = s;
            //{"x":100, "y":100, "Name":"TC"}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            // 使用泛型參考Tloaction物件取得s的資料型態再反序列成obj;
            TLoaction obj = JsonConvert.DeserializeObject<TLoaction>(s);
            button2.Text = obj.Name;
        }
    }

    class TLoaction
    {
        public int x { get; set; }
        public int y { get; set; }
        public string Name { get; set; }
    }
}
