using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers.Api
{
    public class CourseController : ApiController
    {
      
        // GET: api/Course
        public IHttpActionResult Get()
        {
            IList<Course> items = null;

            using (var ctx = new SchoolContext())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                items = ctx.Courses.OrderByDescending(x=>x.CourseID).ToList();
            }

            if (items.Count == 0)
            {
                return NotFound();
            }

            return Ok(items);
        }

        // GET: api/Course/5
        public IHttpActionResult Get(int id)
        {
            Course item = null;

            using (var ctx = new SchoolContext())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                item = ctx.Courses.Find(id);
            }

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/Course
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
