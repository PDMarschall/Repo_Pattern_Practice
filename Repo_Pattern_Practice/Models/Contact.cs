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
        public Zipcode zipcode { get; set; }

        public Addresse addresse { get; set; }

        public Contact()
        {

        }

        public Contact(Addresse addresse, Zipcode zipcode)
        {
            this.addresse = addresse;
            this.zipcode = zipcode;
        }

    }
}
