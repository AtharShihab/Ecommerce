using Ordering.Core.Entities.Base;

namespace Ordering.Core.Entities
{
    public class OrderMaster : BaseEntity
    {
        public Int64 CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OrderNo { get; set; }
        public string? Note { get; set; }

        public ICollection<OrderDetail> Details { get; set; }
    }
}
