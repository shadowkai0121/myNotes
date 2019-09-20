using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
        {
            lblPrompt.Text = "Please keyin your name.";
            return;
        }


        //// DB...

        Response.Cookies["userName"].Value = txtUserName.Text;

        HttpCookie c = Request.Cookies["backTo"];
        if (c == null)
            Response.Redirect("Default.aspx");
        else
        {
            Response.Redirect(c.Value);
            c.Expires = DateTime.Now.AddDays(-1);
        }
    }
}