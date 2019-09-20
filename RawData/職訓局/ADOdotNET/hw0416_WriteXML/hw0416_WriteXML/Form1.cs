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
using System.Data.SqlClient;

namespace hw0416_WriteXML
{
    // 連結北風資料庫
    // 讀取Products內容
    // 使用XMLWriter功能寫成XML文件
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region 連接資料庫
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        private void Connect()
        {
            if (cn.State != ConnectionState.Open) { cn.Open(); }
        }
        #endregion //連接資料庫


        private void btnClick_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Products.xml";
            string sql = "SELECT * FROM Products;";

            Connect();
            //讀取Products
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            cn.Close();

            Conversion(path, da);

            btnClick.Text = "Booom";
        }



        #region 取得欄位名稱
        private static void Conversion(string path, SqlDataAdapter da)
        {
            DataSet ds = new DataSet();
            da.Fill(ds);
            string[] dsCol = new string[ds.Tables[0].Columns.Count];
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                dsCol[i] = ds.Tables[0].Columns[i].ColumnName;
            }

            //使用XMLWriter功能寫成XML
            xmlWrite(ds, dsCol, path);
        }
        #endregion //取得欄位名稱



        #region 使用XmlWriter寫入資料
        private static void xmlWrite(DataSet ds, string[] dsCol, string path)
        {
            XmlWriter w = XmlWriter.Create(path);
            w.WriteStartElement("NorthWind");
            for (int rowNum = 0; rowNum < ds.Tables[0].Rows.Count; rowNum++)
            {
                w.WriteStartElement("Products");

                w.WriteAttributeString("ProductsID", ds.Tables[0].Rows[rowNum][dsCol[0]].ToString());
                for (int colNum = 1; colNum < dsCol.Length; colNum++)
                {
                    w.WriteStartElement(dsCol[colNum]);

                    w.WriteString(ds.Tables[0].Rows[rowNum][dsCol[colNum]].ToString());

                    w.WriteEndElement();//</dsCol>
                }
                w.WriteEndElement();//</Products>
            }
            w.WriteEndElement();//</rss>
            w.Close();
        }
        #endregion //使用XmlWriter寫入資料
    }
}
