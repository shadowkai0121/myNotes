using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace test0429_WebService
{
    /// <summary>
    ///MyWebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public int Add(int x, int y)
        {
            System.Threading.Thread.Sleep(3000);
            // 三秒鐘後執行
            return x + y;
        }


        [WebMethod(enableSession: true)] //使用到SESSION必須要啟用enableSession
        public string SaveData(string key, string data)
        {
            Session[key] = data;
            return data;
        }

        [WebMethod(enableSession: true)]
        public string GetData(string key)
        {
            string result = "";
            if (Session[key] != null)
            {
                result = Session[key].ToString();
            }
            else
            {
                result = "Not found";
            }
            return result;
        }
    }
}
