using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using test0422_DLL;

namespace test0422_EXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Client 提出請求
            // Server 接受請求、提供服務
            CToolBox obj = new CToolBox();
            button1.Text = obj.GetTime();
        }
    }
}
