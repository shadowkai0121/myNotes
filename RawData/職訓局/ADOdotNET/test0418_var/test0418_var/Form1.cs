using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test0418_var
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Employee
        {
            private int _id;
            public int id
            {
                set
                {
                    this._id = value;
                }
                get
                {
                    return this._id;
                }
            }

            public string name { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.id = 1;
            emp.name = "name 1";

            Employee emp2 = new Employee() { id = 2, name = "Derek Jeter" };


            // var 根據等號右邊來決定左邊型別
            // 後補型別
            var emp7 = new Employee() { id = 7, name = "Jeremy Lin" };

            // int x =32; 跟var y = 10;差不多
            // var y = GetData(10); 會有爭議→閱讀時型別不清楚

            // 用類別表示

            //Employee[] empList = new Employee[3];
            //empList[0] = emp;
            //empList[1] = emp2;
            //empList[2] = emp7;


            Employee[] empList = new Employee[] {
                new Employee() { id = 1, name = "Taiwan No. 1" },
                new Employee() { id = 2, name = "Derek Jeter" },
                new Employee() { id = 7, name = "Jeremy Lin" }
            };

            button1.Text = empList[2].name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var emp10 = new { id = 10, LastName = "Messi", country = "A." };
            button2.Text = emp10.GetType().ToString();
            this.Text = emp10.LastName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 彈性新增屬性
            // 物件有各種組合
            var dataList = new[]
            {
                new{id=8, name="emp9"},
                new{id=10,name="emp10"},
                new{id=7, name="emp7"}
            };

            foreach (var data in dataList)
            {
                MessageBox.Show($"{data.id}, {data.name}");
            }
        }
    }
}
