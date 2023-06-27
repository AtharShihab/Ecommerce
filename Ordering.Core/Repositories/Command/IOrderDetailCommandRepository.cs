using Ordering.Core.Entities;
using Ordering.Core.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Repositories.Command
{
    public interface IOrderDetailCommandRepository : ICommandRepository<OrderDetail>
    {
        Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(OrderDetail orderDetail);
    }
}
