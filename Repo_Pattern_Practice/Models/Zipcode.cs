using System.ComponentModel.DataAnnotations;
using Repo_Pattern_Practice.Repository;

namespace Repo_Pattern_Practice.Models
{
    public class Zipcode
    {
        [Key]
        public string Code { get; set; }
        public string City { get; set; }

        public Zipcode()
        {

        }

        public Zipcode (string code, string city)
        {
            Code = code;
            City = city;
        }
    }
}
