using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_0419_LINQ_Anonymous
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Food[] foodList = new Food[] {
                new Food() {id=1, name = "milk", price = 5 },
                new Food() {id=2,  name = "bread", price = 15 },
                new Food() {id=3,  name = "sugar", price = 15 },
                new Food() {id=4,  name = "water", price = 2 }
            };


        private void button1_Click(object sender, EventArgs e)
        {


            //var obj = new { }; //匿名型態 AnonymousType
            //var obj = new { name = "test" }; //由name給予string型態
            var obj = new { name = "test", price = 10 };
            var QFood = from aFood in foodList
                        where aFood.price >= 10
                        select aFood;

            //var dataList = QFood.ToList();
            //dataGridView1.DataSource = dataList;

            var dataList = QFood.ToList();
            foreach (var item in dataList)
            {
                item.price = item.price * 10;
            }
            dataGridView1.DataSource = dataList;
            button1.Text = foodList[1].price.ToString();

            // 使用動態屬性方法替代var
            // 會造成管理上的不確定性
            //testFood(obj);

        }

        // 使用動態屬性物件替代var
        // 會造成管理上的不確定性
        void testFood(dynamic obj2) //動態屬性物件
        { MessageBox.Show(obj2.name); }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = foodList[1].price.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var QFood = from o in foodList
                        where o.price >= 10
                        select new { name = o.name, price = o.price * 30 };

            // 投影會成為新的類別、新的實體
            var dataBag = QFood.ToList();
            dataGridView1.DataSource = dataBag;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region 沒有LINQ的狀況
            //Food foundFood = null;
            //foreach (Food food in foodList)
            //{
            //    if (food.price == 15)
            //    {
            //        foundFood = food;
            //        break;
            //    }
            //}
            //if (foundFood == null)
            //{ button4.Text = "not found"; }
            //else
            //{ button4.Text = foundFood.name; }
            #endregion

            // LINQ
            var QFood = from o in foodList
                        where o.price == 15
                        select o;

            Food target = QFood.FirstOrDefault(); //First or Null
            //Food target = QFood.SingleOrDefault(); // 限定一個
            if (target == null)
            { button4.Text = "not found"; }
            else
            { button4.Text = target.name.ToString(); }
        }
    }
    // 定義型別
    class Food
    {
        public int id { set; get; }
        public string name { set; get; }
        public int price { set; get; }
    }
}
