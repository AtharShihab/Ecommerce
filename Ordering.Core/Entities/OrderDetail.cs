using Ordering.Core.Entities.Base;

namespace Ordering.Core.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Int64 MasterId { get; set; }
        public OrderMaster Master { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
