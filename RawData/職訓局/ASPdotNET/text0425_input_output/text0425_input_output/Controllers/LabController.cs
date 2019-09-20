using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace text0425_input_output.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            return View();
        }

        // http://localhost:49639/Lab/TestQueryString?FirstName=Jeremy
        //public ActionResult TestQueryString()
        //{
        //    string result = Request.QueryString["FirstName"];
        //    return Content(result);
        //}

        // MVC建議的做法
        //http://localhost:49639/Lab/TestQueryString?FirstName=Jeremy&LastName=Lin
        //public ActionResult TestQueryString
        //    (string LastName, string FirstName)
        //{
        //    string result = FirstName + " " + LastName;
        //    return Content(result);
        //}

        public ActionResult TestQueryString
          (string LastName, string FirstName)
        {
            string result = string.Format($"FirstName: {FirstName}</br>" +
                $"LastName: {LastName}");
            return Content(result);
        }

        //public ActionResult TestInput
        // (string LastName, string FirstName)
        //{
        //    string result = string.Format($"FirstName: {FirstName}</br>" +
        //        $"LastName: {LastName}");
        //    return Content(result);
        //}

        //public ActionResult TestInput()
        //{
        //    string result = string.Format(
        //        $"FirstName: {Request.Form["FirstName"]}</br>" +
        //        $"LastName: {Request.QueryString["LastName"]}");
        //    return Content(result);
        //}

        //public ActionResult TestInput(Models.Employee emp)
        //{
        //    string result = string.Format(
        //        $"FirstName: {emp.FirstName}</br>" +
        //        $"LastName: {emp.LastName}</br>");
        //    return Content(result);
        //}

        // 瀏覽器分不出來相同名稱
        // Hello World!!
        [HttpGet]
        public ActionResult Hello()
        {
            Models.Employee emp = new Models.Employee();
            ViewBag.why = "";
            return View(emp);
        }

        [HttpPost]
        public ActionResult Hello(Models.Employee emp)
        {
            if (string.IsNullOrEmpty(emp.FirstName) || emp.FirstName.ToLower() == "guest")
            {
                ViewBag.why = "Please key-in your name.";
                //TempData["ErrorMessage"] = "don't guest";
                return View("Hello", emp);
            }
            return Content(emp.FirstName);
        }
    }
}