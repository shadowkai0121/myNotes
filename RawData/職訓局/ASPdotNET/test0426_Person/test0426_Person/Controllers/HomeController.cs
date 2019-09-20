using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test0426_Person.Models;

namespace test0426_Person.Controllers
{
    public class HomeController : Controller
    {
        db0426Entities db = new db0426Entities();
        // GET: Home
        public ActionResult Index()
        {
            var Q = from o in db.People
                    select o;
            return View(Q.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            db.People.Add(p);
            db.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult Edit(int? id)
        {
            var Q = from o in db.People
                    where o.PersonId == id
                    select o;

            Person p = Q.FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            var Q = from o in db.People
                    where o.PersonId == p.PersonId
                    select o;

            Person ServerPerson = Q.FirstOrDefault();
            ServerPerson.BloodType = p.BloodType;
            ServerPerson.CityId = p.CityId;

            //  ServerPerson.BloodType = p.BloodType; v
            //  ServerPerson.BloodType = [] → ServerPerson.BloodType
            //  ServerPerson.BloodType = [] →null

            db.SaveChanges();

            return Redirect("Index");
        }

    }
}