﻿using System.ComponentModel.DataAnnotations;

namespace Repo_Pattern_Practice.DatabaseEntities
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
        public string City { get; set; }
    }
}
