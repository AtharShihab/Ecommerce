using MediatR;
using Ordering.Application.DTOs;
using Ordering.Application.Mapper;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Commands.Orders.Create
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public Int64 CustomerId { get; set; }
        public string OrderNo { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CreateOrderDetailCommand> Details { get; set; }

        public CreateOrderCommand()
        {
            CreatedDate = DateTime.Now;
        }
    }

    public class CreateOrderDetailCommand
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedDate { get; set;}

        public CreateOrderDetailCommand()
        {
            CreatedDate = DateTime.Now;
        }

    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderMasterCommandRepository _orderMasterCommandRepository;
        private readonly IOrderDetailCommandRepository _orderDetailCommandRepository;

        public CreateOrderCommandHandler(IOrderMasterCommandRepository orderMasterCommandRepository, IOrderDetailCommandRepository orderDetailCommandRepository)
        {
            _orderMasterCommandRepository = orderMasterCommandRepository;
            _orderDetailCommandRepository = orderDetailCommandRepository;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderMasterEntity = CustomMapper.Mapper.Map<CreateOrderCommand, OrderMaster>(request);

            if (orderMasterEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            var newOrder = await _orderMasterCommandRepository.AddOrderMasterAsync(orderMasterEntity);
            var orderDetails = orderMasterEntity.Details;
            var newDetails = new List<OrderDetail>();
            foreach (var detail in orderDetails)
            {
                detail.MasterId = newOrder.Id;
                var newDetail = await _orderDetailCommandRepository.AddOrderDetailAsync(detail);
                newDetails.Add(newDetail);
            }
            newOrder.Details= newDetails;
            var orderResponse = CustomMapper.Mapper.Map<OrderMaster, OrderResponse>(newOrder);

            return orderResponse;
        }
    }
}
