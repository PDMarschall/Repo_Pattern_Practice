﻿using Repo_Pattern_Practice.DatabaseEntities;

namespace Repo_Pattern_Practice.Repository
{
    public class AddressRepository : GenericRepository<Addresse>
    {
        public AddressRepository(ApplicationContext context) : base(context)
        {

        }
    }
}