using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;

namespace ContosoUniversity.ViewModels
{
    public class PeopleSearch
    {
        public string PersonID { get; set; }
        public string Name { get; set; }
        public string PersonType { get; set; }

        public int PageSize { get { return 10; } }

        public IEnumerable<Person> People { get; set; }

        public bool Empty
        {
            get
            {
                return (string.IsNullOrWhiteSpace(PersonID) &&
                        string.IsNullOrWhiteSpace(Name) &&
                        string.IsNullOrWhiteSpace(PersonType));
            }
        }

    }
}