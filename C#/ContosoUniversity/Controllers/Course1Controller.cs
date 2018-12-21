using ContosoUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;
using System.Data.Entity;

namespace ContosoUniversity.Controllers
{
    public class Course1Controller : Controller
    {
        private SchoolContext db = new SchoolContext();

        public Course1Controller()
        {
            ViewBag.Departments = db.Departments.Select(o => new SelectListItem { Value = o.DepartmentID.ToString(), Text = o.Name }).Distinct().OrderBy(x => x.Text).ToList();
            ViewBag.CourseTitle = db.Courses.Select(x => x.Title).OrderBy(x=>x).ToList();
            var instructors = db.Instructors.ToList();
            ViewBag.Instructors = instructors.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.FullName }).Distinct().OrderBy(x => x.Text).ToList();
        }

        // GET: Course1
        public ActionResult Index()
        {
            var search = new CoursesSearch();
            search.Courses = db.Courses.Take(10).ToList();
            return View(search);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CoursesSearch model)
        {
            // Get Leases
            if (model.Empty)
            {
                model.Courses = db.Courses.Take(10).ToList();
            }
            else
            {
                model.Courses = db.Courses
                   .Where(x =>
                             (String.IsNullOrEmpty(model.CourseID) || x.CourseID.ToString().Contains(model.CourseID.Trim()))
                              && (String.IsNullOrEmpty(model.Title) || x.Title.ToLower().Trim().Contains(model.Title.ToLower().Trim()))
                              && (String.IsNullOrEmpty(model.Credits) || x.Credits.ToString().Equals(model.Credits.Trim()))
                              && (String.IsNullOrEmpty(model.DepartmentID) || x.DepartmentID.ToString().Equals(model.DepartmentID.Trim()))
                             ).OrderBy(x => x.Title).ToList();
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var item  = db.Courses.Find(id);
            if (item == null)
                return HttpNotFound();

            var details = GetDetails(id);

            return View("Details", details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(CoursesDetails model)
        {
            var CourseID = UpdateCourse(model.Course);

            if (CourseID == 0)
                return HttpNotFound();

            var details = GetDetails(CourseID);

            return View("Details", details);
        }

        [HttpPost]
        public ActionResult AddCourseInstructor(CourseInstructor item)
        {
            var course = db.Courses.Find(item.CourseID);
            var instructor = db.Instructors.Find(item.InstructorID);

            if (course != null && instructor != null)
            {
                course.Instructors.Add(instructor);

                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
            }

            return PartialView("~/Views/Shared/Instructor/_Instructor.cshtml", instructor); 
        }

        #region Save and Update date into Database

        public CoursesDetails GetDetails(int CourseID)
        {
            var details = new CoursesDetails();
            var item = db.Courses.Find(CourseID);
            details.Course = item;
            details.Instructors = item.Instructors;

            var newCourseInstructor = new CourseInstructor();
            newCourseInstructor.CourseID = item.CourseID;
            details.NewCourseInstructor = newCourseInstructor;

            return details;
        }

        public int UpdateCourse(Course item)
        {
            var itemToUpdate = db.Courses.Find(item.CourseID);
            
            if (itemToUpdate != null)
            {
                itemToUpdate.Title = item.Title;
                itemToUpdate.Credits = item.Credits;
                itemToUpdate.DepartmentID = item.DepartmentID;
                
                db.Entry(itemToUpdate).State = EntityState.Modified;
                db.SaveChanges();

            }
            else
            {
                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
            }

            return item.CourseID;

        }

       

        #endregion
    }
}