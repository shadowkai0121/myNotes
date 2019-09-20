using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test_424_Employee
{
    public partial class employeeDetail : System.Web.UI.Page
    {
        public employee emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = -1;
            // Request.QueryString[] = Request[]
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            { id = 1; }
            else
            { id = Convert.ToInt32(Request.QueryString["id"]); }
            directoryEntities db = new directoryEntities();
            var Q = from o in db.employees
                    where o.id == id
                    select o;
            emp = Q.FirstOrDefault();
        }
    }
}