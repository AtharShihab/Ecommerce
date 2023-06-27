using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Repositories.Query
{
    public interface IOrderMasterQueryRepository : IQueryRepository<OrderMaster>
    {
        Task<IQueryable<OrderMaster>> GetAllAsync();
        Task<IQueryable<OrderMaster>> GetByIdAsync(int id);
    }
}
