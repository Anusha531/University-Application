using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;

namespace ContosoUniversity.ViewModels
{
    public class CoursesDetails
    {
        public Course Course { get; set; }
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public CourseInstructor NewCourseInstructor { get; set; }
    }
}