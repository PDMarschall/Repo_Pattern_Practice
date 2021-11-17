using System.ComponentModel.DataAnnotations;

namespace Repo_Pattern_Practice.DatabaseEntities
{
    public class Address
    {
        [Key]
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Vejnummer { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Postnummer { get; set; }

    }
}
