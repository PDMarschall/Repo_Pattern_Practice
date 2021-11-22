using Repo_Pattern_Practice.Models;
using System;

namespace Repo_Pattern_Practice.Repository
{
    public class ZipcodeRepository : GenericRepository<Zipcode>
    {
        public ZipcodeRepository(ApplicationContext context) : base(context)
        {

        }

        public Zipcode ReturnZipCode(string code)
        {
            return context.Find<Zipcode>(code);
        }
    }
}
