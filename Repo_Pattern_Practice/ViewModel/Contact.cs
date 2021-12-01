using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repo_Pattern_Practice.Models;

namespace Repo_Pattern_Practice.ViewModel
{
    public class Contact
    {
        public Zipcode Zipcode { get; set; }

        public Addresse Addresse { get; set; }

        public Contact()
        {

        }

        public Contact(Addresse a, Zipcode z)
        {
            Addresse = a;
            Zipcode = z;
        }

    }
}
