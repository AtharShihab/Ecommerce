using AutoMapper;
using Ordering.Application.Commands.Customers.Create;
using Ordering.Application.Commands.Customers.Update;
using Ordering.Application.Commands.Orders.Create;
using Ordering.Application.DTOs;
using Ordering.Core.Entities;

namespace Ordering.Application.Mapper
{
    public class OrderingMappingProfile : Profile
    {
        public OrderingMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();
            CreateMap<OrderMaster, CreateOrderCommand>().ReverseMap();
            CreateMap<OrderMaster, OrderResponse>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailResponse>().ReverseMap();
        }
    }
}
