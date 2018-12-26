using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Document
    {
        public int DocumentID { get; set; }

        public string DocumentName { get; set; }

        public string Description { get; set; }

        public string DocumentType { get; set; }

        public string DocumentLink { get; set; }

        public string Comment { get; set; }

        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string UploadedUser { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Uploaded Date")]
        public DateTime UploadedDate { get; set; }

        public string ModifiedUser { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        public virtual Course Course { get; set; }
    }


}