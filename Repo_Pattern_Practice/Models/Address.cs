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
        [ForeignKey("Code")]
        public string Zipcode { get; set; }
    }
}
