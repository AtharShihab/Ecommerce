using MediatR;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;

namespace Ordering.Application.Queries.Customers
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Int64 Id { get; private set; }

        public GetCustomerByIdQuery(long id)
        {
            this.Id = id;
        }
    }


    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerQueryRepository.GetByIdAsync(request.Id);
            throw new NotImplementedException();
        }
    }
}
