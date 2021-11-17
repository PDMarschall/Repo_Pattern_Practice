using Repo_Pattern_Practice.DatabaseEntities;

namespace Repo_Pattern_Practice.Repository
{
    class AddressRepository : GenericRepository<Address>
    {
        public AddressRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
