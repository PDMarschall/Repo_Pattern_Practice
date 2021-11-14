using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repo_Pattern_Practice.DatabaseEntities;

namespace Repo_Pattern_Practice.Repository
{
    public class ZipcodeRepository : GenericRepository<Zipcode>
    {

        public ZipcodeRepository(ApplicationContext context) : base(context)
        {

        }

        public override IEnumerable<Zipcode> Select(Expression<Func<Zipcode, bool>> predicate)
        {
            return context.Set<Zipcode>()
            .AsQueryable()
            .Where(predicate).ToList();
        }
    }
}

