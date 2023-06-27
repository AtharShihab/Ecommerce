using MediatR;
using Ordering.Core.Repositories.Command;
using Ordering.Core.Repositories.Query;

namespace Ordering.Application.Commands.Customers.Delete
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public Int64 Id { get; private set; }

        public DeleteCustomerCommand(Int64 Id)
        {
            this.Id = Id;
        }
    }


    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public DeleteCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerEntity = await _customerQueryRepository.GetByIdAsync(request.Id);

                await _customerCommandRepository.DeleteAsync(customerEntity);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }

            return "Customer information has been deleted";
        }
    }
}
