using Repo_Pattern_Practice.Models;

namespace Repo_Pattern_Practice.Repository
{
    public class ZipcodeRepository : GenericRepository<Zipcode>
    {
        public ZipcodeRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
