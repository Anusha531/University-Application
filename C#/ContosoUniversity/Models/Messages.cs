using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Messages
    {
        public int id { get; set; }

        public int UserID { get; set; }

        public int toId { get; set; }

        public string msg { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? read_at { get; set; }

        public virtual User User { get; set; }

    }
}