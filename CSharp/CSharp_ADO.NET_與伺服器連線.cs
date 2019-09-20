using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace text0411_Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            // Data Source = Server;
            // Initial Catalog = Database;
            // Intergated Security = true => 本機認證;
            // user id = uid;
            // password = pwd;

            SqlConnection cn = new SqlConnection($@"Server=.;Database=Northwind;Integrated Security= false; uid = {txtAccount.Text}; pwd= {txtPwd.Text}");
            try
            {
                cn.Open();
                MessageBox.Show("登入成功");
            }
        }
    }
}
