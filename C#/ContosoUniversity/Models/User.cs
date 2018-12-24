using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class User
    {
        public int UserID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Roles{ get; set; }

    }
}