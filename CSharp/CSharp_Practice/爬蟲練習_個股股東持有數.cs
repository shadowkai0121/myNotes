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

namespace Spider_v0423
{
    public partial class 爬蟲練習_個股股東持有數 : Form
    {
        public 爬蟲練習_個股股東持有數()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtQuery.Text) < 1000 || int.Parse(txtQuery.Text) > 9999)
            {
                MessageBox.Show("股號打錯了!!");
                txtQuery.Clear();
                txtQuery.Focus();
                return;
            }
            string sURL = @"http://just2.entrust.com.tw/z/zc/zck/zck_" + txtQuery.Text + ".djhtm";

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.LoadFromBrowser(sURL);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//*[@id=\"SysJustIFRAMEDIV\"]/table/tbody/tr[2]/td[2]/center/table/tbody/tr[1]/td/table/tbody/tr");

            TestbaseEntities db = new TestbaseEntities();
            foreach (HtmlNode node in nodes)
            {
                // 跳開表頭
                if (node.SelectSingleNode("./td").Attributes["class"].Value == "t2")
                { continue; }

                // 比對重複
                string num = txtQuery.Text;
                string name = "";
                try
                { name = node.SelectSingleNode("./td[2]").InnerText; }
                catch
                { continue; }
                decimal rate = Convert.ToDecimal(node.SelectSingleNode("./td[4]").InnerText.TrimEnd('%'));
                var checkQ = from o in db.ShareHolders
                             where o.StockSymbol == num && o.HolderName == name && o.HoldingRate == rate
                             select o;
                if (checkQ.ToList().Count() != 0)
                {
                    continue;
                }

                //寫入資料
                ShareHolder data = new ShareHolder();
                data.StockSymbol = txtQuery.Text;
                data.Position = node.SelectSingleNode("./td[1]").InnerText;
                data.HolderName = node.SelectSingleNode("./td[2]").InnerText;
                data.HoldingRate = Convert.ToDecimal(node.SelectSingleNode("./td[4]").InnerText.TrimEnd('%'));
                data.PledgeRate = Convert.ToDecimal(node.SelectSingleNode("./td[6]").InnerText.TrimEnd('%'));
                db.ShareHolders.Add(data);
            Retry:
                try
                { db.SaveChanges(); }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                {
                    // 更新實體資料模型
                    ex.Entries.Single().Reload();
                    goto Retry;
                }
            }
            var Q = from o in db.ShareHolders
                    where o.StockSymbol == txtQuery.Text
                    select o;
            dataGridView1.DataSource = Q.ToList();
            btnQuery.Text = "ok";
        }
    }
}
