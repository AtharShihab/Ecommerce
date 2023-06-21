using Ordering.Core.Entities;
using Ordering.Core.Repositories.Command;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Command.Base;

namespace Ordering.Infrastructure.Repositories.Command
{
    public class CommandCustomerRepository : CommandRepository<Customer>, ICommandCustomerRepository
    {
        public CommandCustomerRepository(OrderingContext context) : base(context)
        {
        }
    }
}
