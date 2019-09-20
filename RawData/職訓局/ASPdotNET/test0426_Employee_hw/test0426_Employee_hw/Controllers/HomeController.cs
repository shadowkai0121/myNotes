using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test0426_Employee_hw.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Models.directoryEntities db = new Models.directoryEntities();
        public ActionResult Index()
        {
            var Q = from o in db.employees
                    select o;
            return View(Q.ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return Redirect("Index");
            }

            var Q = from o in db.employees
                    where o.id == id
                    select o;

            return View(Q.ToList());
        }

        public ActionResult Update(int? id)
        {
            //if (string.IsNullOrEmpty(id.ToString()))
            //{ return View(); }
            //var Q = from o in db.employees
            //        select o;
            return View();
        }
    }
}