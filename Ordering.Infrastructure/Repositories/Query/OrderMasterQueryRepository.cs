using Microsoft.Extensions.Configuration;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Query
{
    public class OrderMasterQueryRepository : QueryRepository<OrderMaster>, IOrderMasterQueryRepository
    {
        public OrderMasterQueryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public Task<IQueryable<OrderMaster>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<OrderMaster>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
