using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Pattern_Practice.DatabaseEntities
{
    public class Address
    {
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Vejnummer { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }

        public Zipcode zipcode;

    }
}
