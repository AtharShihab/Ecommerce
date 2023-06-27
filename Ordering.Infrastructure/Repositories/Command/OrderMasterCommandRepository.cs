using Microsoft.Data.SqlClient;
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
            //var param = new SqlParameter[]
            //{
            //    new SqlParameter()
            //    {
            //        ParameterName = "CustomerId",
            //        SqlDbType = System.Data.SqlDbType.BigInt,
            //        Value = orderMaster.CustomerId
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "OrderNo",
            //        SqlDbType = System.Data.SqlDbType.NVarChar,
            //        Value = orderMaster.OrderNo
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "Note",
            //        SqlDbType = System.Data.SqlDbType.NVarChar,
            //        Value = orderMaster.Note
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "CreatedDate",
            //        SqlDbType = System.Data.SqlDbType.DateTime2,
            //        Value = orderMaster.CreatedDate
            //    },
            //    new SqlParameter()
            //    {
            //        ParameterName = "ModifiedDate",
            //        SqlDbType = System.Data.SqlDbType.DateTime2,
            //        Value = orderMaster.ModifiedDate
            //    },
            //};
            
            //var id = await _context.Database.ExecuteSqlRawAsync($"Exec Order_Master_Insert @CustomerId, @OrderNo, @Note, @CreatedDate, @ModifiedDate", param);
            //orderMaster.Id = id;

            _context.OrderMasters.Add(orderMaster);
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
