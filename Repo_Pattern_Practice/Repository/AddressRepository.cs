using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
