using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo_Pattern_Practice.Models
{
    public class Addresse
    {
        [Key]
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Zipcode { get; set; }

        public Addresse()
        {

        }

        public Addresse(string ph, string fi, string la, string ad, string zi, string em, string ti)
        {
            Phone = ph;
            FirstName = fi;
            LastName = la;
            Address = ad;
            Zipcode = zi;
            Email = em;
            Title = ti;
        }
    }
}
