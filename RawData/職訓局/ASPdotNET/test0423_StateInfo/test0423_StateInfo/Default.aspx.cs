using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test0423_StateInfo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 可以在瀏覽器之間共享
            // 生命週期只到改版為止(修改並存檔)
            Application["shared"] = TextBox1.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // session不能共用
            TextBox1.Text = Application["shared"].ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["who"] = TextBox2.Text;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox2.Text = Session["who"].ToString();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // 沒有有效期限代表關掉瀏覽器就消失了
            // 必須將COOKIE加密才有可能避免變造 
            // COOKIE可以在瀏覽器CONSOLE被修改
            Response.Cookies["userName"].Value = TextBox3.Text;

            // 設定存在時間
            // 計算的是格林威治時間
            Response.Cookies["userName"].Expires =
                 DateTime.Now.AddDays(3);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["userName"];
            if (c == null)
            {
                TextBox3.Text = "no cookie found";
            }
            else
            {
                TextBox3.Text = c.Value;
            }
        }
    }
}