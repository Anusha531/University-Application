using ContosoUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers.Api
{
    public class DocumentController : ApiController
    {
      
        public IHttpActionResult PostNewDocument(Document document)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var doc = new Document();

            using (var db = new SchoolContext())
            {
                doc.DocumentName = document.DocumentName;
                doc.CourseID = document.CourseID;
                doc.UploadedDate = document.UploadedDate;
                doc.UploadedUser = document.UploadedUser;                

                db.Entry(doc).State = EntityState.Added;
                db.SaveChanges();
            }

            return Ok(doc.DocumentID.ToString());
        }

      

        public IHttpActionResult Delete(int Id)
        {
            if (Id <= 0)
                return BadRequest("Not a valid document id");

            using (var db = new SchoolContext())
            {
                var item = db.Documents.Find(Id);

                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
