using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data.SqlClient;
using System.Data;

namespace test0422_WebService
{
    /// <summary>
    ///WebService1 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWho(string who)
        {
            return $"Hello World, {who}";
        }

        // 可以傳遞資料集
        [WebMethod]
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection("server=.;database=northwind;integrated security=true;");
            SqlDataAdapter da = new SqlDataAdapter("select * from products", cn);
            da.Fill(ds, "Products");

            return ds;
        }
    }
}
