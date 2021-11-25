using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Pattern_Practice.Models
{
    public class Contact
    {
        public Zipcode Zipcode { get; set; }

        public Addresse Addresse { get; set; }

        public Contact()
        {

        }

        public Contact(Addresse addresse, Zipcode zipcode)
        {
            Addresse = addresse;
            Zipcode = zipcode;
        }

    }
}
