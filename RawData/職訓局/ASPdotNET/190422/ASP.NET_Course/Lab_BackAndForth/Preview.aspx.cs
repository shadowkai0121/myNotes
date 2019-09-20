using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUserName.Text = Session["userName"].ToString();
        lblPassword.Text = Session["password"].ToString();
        lblEmail.Text = Session["email"].ToString();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session["userName"] = lblUserName.Text;
        Session["password"] = lblPassword.Text;
        Session["email"] = lblEmail.Text;

        Response.Redirect("NewMember.aspx");
    }
}