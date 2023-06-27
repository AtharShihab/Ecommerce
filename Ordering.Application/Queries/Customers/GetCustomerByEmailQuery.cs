using MediatR;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;

namespace Ordering.Application.Queries.Customers
{
    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string Email { get; private set; }

        public GetCustomerByEmailQuery(string email)
        {
            this.Email = email;
        }
    }


    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerByEmailQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _customerQueryRepository.GetCustomerByEmailAsync(request.Email);
        }
    }
}
