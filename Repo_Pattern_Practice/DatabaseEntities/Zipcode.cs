using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Pattern_Practice.DatabaseEntities
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
