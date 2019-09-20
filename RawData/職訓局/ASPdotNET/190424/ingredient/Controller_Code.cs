
    public class LabController : Controller {
        // GET: Lab
        public ActionResult Index() {
            return View();
        }

        [ActionName("AboutMe")]
        public ActionResult About() {
            return View("About");
        }

        public ActionResult TestText() {
            return Content("Hello! World.");
        }

        public ActionResult TestXML() {
            //ContentResult result = new ContentResult();
            //result.Content = "<book><title>bookName</title><price>500</price></book>";
            //result.ContentType = "text/xml";
            ContentResult result = new ContentResult {
                Content = "<book><title>bookName</title><price>500</price></book>",
                ContentType = "text/xml",
                ContentEncoding = System.Text.Encoding.UTF8
            };

            return result;
        }

        public ActionResult TestEmpty() {
            return null;
        }

        // http://localhost:49665/Lab/TestRedirect
        public ActionResult TestRedirect() {
            // return Redirect("http://www.hinet.net");
            return RedirectToAction("About", "Home");
        }

        [NonAction]
        public ActionResult TestNoAction() {
            return Content("TEST NO ACTION");
        }

        // http://localhost:49665/Lab/TestQueryString?FirstName=Jeremy&LastName=Lin
        public ActionResult TestQueryString() {
            string result = string.Format(
                "FirstName = {0} <br> LastName = {1}",
                Request.QueryString["FirstName"],
                Request["LastName"]
                );
            return Content(result);
        }

        //http://localhost:49665/Lab/TestInput?FirstName=Jeremy&LastName=Lin
        //public ActionResult TestInput(string LastName, string FirstName) {
        //    string result = string.Format(
        //        "FirstName => {0} <br> LastName => {1}",
        //        FirstName,
        //        LastName
        //        );
        //    return Content(result);
        //}

        //public ActionResult TestInput(FormCollection frm) {
        //    string result = string.Format(
        //        "FirstName :: {0} <br> LastName :: {1}",
        //        frm["FirstName"],
        //        frm["LastName"]
        //        );
        //    return Content(result);
        //}

        public ActionResult TestInput(Employee emp) {
            string result = string.Format(
                "FirstName ::> {0} <br> LastName ::> {1}",
                emp.FirstName,
                emp.LastName
                );
            return Content(result);
        }

        public ActionResult TestID(string id) {
            return Content("ID: " + id);
        }

        public ActionResult TestViewBag() {
            ViewBag.FirstName = "Jeremy";
            return View();
        }

        public ActionResult TestViewData() {
            ViewData["FirstName"] = "Derek";
            TempData["FirstName"] = "La-La Bear";
            // return View();
            return RedirectToAction("ShowData", "Lab");
        }

        public ActionResult ShowData() {
            return RedirectToAction("ShowDataAgain", "Lab");
        }

        public ActionResult ShowDataAgain() {
            return View();
        }

        public ActionResult TestModel() {
            Employee emp = new Employee {
                FirstName = "Jeremy",
                LastName = "Lin"
            };
            return View(emp);
        }

        public ActionResult GetOrPost() {
            return Content("GET");
        }

        [HttpPost]
        public ActionResult GetOrPost(FormContext frm) {
            return Content("POST");
        }

        public ActionResult Hello() {
            Employee emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Hello(Employee emp) {
            if (!ModelState.IsValid) {
                return View(emp);
            }
            //if (!emp.IsValid()) {
            //    return View(emp);
            //}
            TempData["emp"] = emp;
            return RedirectToAction("SayHello", "Lab");
        }

        public ActionResult SayHello() {
            Employee emp = TempData["emp"] as Employee;
            return View(emp);
        }

    }

