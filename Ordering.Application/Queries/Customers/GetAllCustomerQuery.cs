using MediatR;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;

namespace Ordering.Application.Queries.Customers
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {

    }


    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        public readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAllCustomerQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return (List<Customer>)await _customerQueryRepository.GetAllAsync();
        }
    }
}
