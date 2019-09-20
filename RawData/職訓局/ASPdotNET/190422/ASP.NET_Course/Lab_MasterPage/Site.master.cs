using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Trace.Warn("Master's Page_Load");
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        Trace.Warn("Master's PreRender");
        lblTest.Text = Session["lbl"].ToString();
    }

}

