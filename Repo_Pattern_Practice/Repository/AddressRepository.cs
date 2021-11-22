using Microsoft.EntityFrameworkCore;
using Repo_Pattern_Practice.Models;
using System.Linq;

namespace Repo_Pattern_Practice.Repository
{
    public class AddressRepository : GenericRepository<Addresse>
    {
        public AddressRepository(ApplicationContext context) : base(context)
        {

        }
    }
}