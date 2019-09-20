using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test_424_Employee.Design
{
    public partial class Default : System.Web.UI.Page
    {
        public List<employee> empList;
        protected void Page_Load(object sender, EventArgs e)
        {
            directoryEntities db = new directoryEntities();
            var Q = from o in db.employees
                    select o;
            empList = Q.ToList();
        }
    }
}