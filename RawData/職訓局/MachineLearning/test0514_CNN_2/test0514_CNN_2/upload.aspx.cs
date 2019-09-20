using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test0514_CNN_2
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile f = Request.Files[i];
                f.SaveAs(Server.MapPath("/tfModels/" + f.FileName));
            }

            Response.End()
        }
    }
}