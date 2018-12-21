using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;

namespace ContosoUniversity.ViewModels
{
    public class CoursesSearch
    {
        public string CourseID { get; set; }
        public string Title { get; set; }
        public string Credits { get; set; }
        public string DepartmentID { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public bool Empty
        {
            get
            {
                return (string.IsNullOrWhiteSpace(CourseID) &&
                        string.IsNullOrWhiteSpace(Title) &&
                        string.IsNullOrWhiteSpace(Credits) &&
                        string.IsNullOrWhiteSpace(DepartmentID));
                        
            }
        }
    }
}