using ContosoUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.ViewModels;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class PeopleController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: Person
        public ActionResult Index()
        {
            var search = new PeopleSearch();
            search.People = db.People.Take(search.PageSize);            
            return View(search);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PeopleSearch model)
        {
            // Get Leases
            if (model.Empty)
            {
                model.People = db.People.Take(model.PageSize);
            }
            else
            {
                model.People = db.People
                   .Where(
                       x =>
                       (String.IsNullOrEmpty(model.PersonID) || x.ID.ToString().Equals(model.PersonID.Trim()))
                       && (String.IsNullOrEmpty(model.Name) || x.LastName.ToLower().Trim().Contains(model.Name.ToLower().Trim()) || x.FirstMidName.ToLower().Trim().Contains(model.Name.ToLower().Trim()))
                       //&& (String.IsNullOrEmpty(model.Name) || x.FirstMidName.ToLower().Trim().Contains(model.Name.ToLower().Trim()))
                         ).OrderBy(x => x.ID).ToList();
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var item = db.People.Find(id);

            if (item == null)
                return HttpNotFound();

            return View("Details", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Person model)
        {
            return View("Details", model);
        }
    }
}