using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Command;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Command
{
    public class OrderMasterCommandRepository : CommandRepository<OrderMaster>, IOrderMasterCommandRepository
    {
        public OrderMasterCommandRepository(OrderingContext context) : base(context)
        {

        }
        public async Task<OrderMaster> AddOrderMasterAsync(OrderMaster orderMaster)
        {
            var i =  await _context.OrderMasters.AddAsync(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster;
        }

        public async Task DeleteOrderMasterAsync(OrderMaster orderMaster)
        {
            _context.OrderMasters.Remove(orderMaster);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderMasterAsync(OrderMaster orderMaster)
        {
            _context.Entry(orderMaster).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
