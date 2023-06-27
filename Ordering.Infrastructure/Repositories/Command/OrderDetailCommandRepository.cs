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
    public class OrderDetailCommandRepository : CommandRepository<OrderDetail>, IOrderDetailCommandRepository
    {
        public OrderDetailCommandRepository(OrderingContext context) : base(context)
        {
        }

        public async Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter()
                {
                    ParameterName = "MasterId",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Value = orderDetail.MasterId
                },
                new SqlParameter()
                {
                    ParameterName = "ItemName",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Value = orderDetail.ItemName
                },
                new SqlParameter()
                {
                    ParameterName = "Quantity",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = orderDetail.Quantity
                },
                new SqlParameter()
                {
                    ParameterName = "Price",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = orderDetail.Price
                },
                new SqlParameter()
                {
                    ParameterName = "CreatedDate",
                    SqlDbType = System.Data.SqlDbType.DateTime2,
                    Value = orderDetail.CreatedDate
                },
                new SqlParameter()
                {
                    ParameterName = "ModifiedDate",
                    SqlDbType = System.Data.SqlDbType.DateTime2,
                    Value = orderDetail.ModifiedDate
                }
            };
            
            var id = await _context.Database.ExecuteSqlRawAsync($"Exec Order_Detail_Insert @MasterId, @ItemName, @Quantity, @Price, @CreatedDate, @ModifiedDate", param);
            orderDetail.Id = id;
            return orderDetail;
        }

        public async Task DeleteOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.Entry(orderDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
