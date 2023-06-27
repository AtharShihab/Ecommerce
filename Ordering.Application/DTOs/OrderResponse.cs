using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.DTOs
{
    public class OrderResponse
    {
        public string Customer { get; set; }
        public string OrderNo { get; set; }
        public string? Note { get; set; }

        public List<OrderDetailResponse> Details { get; set; }
    }

    public class OrderDetailResponse 
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
