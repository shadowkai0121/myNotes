using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test0422_Hello
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果頁面並不是PostBack才執行
            if (!this.IsPostBack)
            { TextBox1.Text = "Key in here"; }
            Trace.Warn("Hello! ASP");
            Label1.Text = "hi";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["who"] = TextBox1.Text;
            Response.Redirect("Hello.aspx");
        }
    }
}