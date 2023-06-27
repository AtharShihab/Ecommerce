using Ordering.Core.Entities;
using Ordering.Core.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Repositories.Command
{
    public interface IOrderMasterCommandRepository : ICommandRepository<OrderMaster>
    {
        Task<OrderMaster> AddOrderMasterAsync(OrderMaster orderMaster);
        Task UpdateOrderMasterAsync(OrderMaster orderMaster);
        Task DeleteOrderMasterAsync(OrderMaster orderMaster);
    }
}
