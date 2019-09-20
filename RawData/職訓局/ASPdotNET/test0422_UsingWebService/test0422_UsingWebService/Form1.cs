using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using test0422_UsingWebService.localhost;

namespace test0422_UsingWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = webService11.HelloWho("123");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            WebService1 ws = new WebService1();
            ds = ws.GetData();
            
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
