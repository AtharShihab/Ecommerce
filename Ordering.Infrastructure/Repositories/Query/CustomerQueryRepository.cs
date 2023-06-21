using Microsoft.Extensions.Configuration;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;
using Ordering.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Query
{
    internal class CustomerQueryRepository : QueryRepository<Customer>,ICustomerQueryRepository
    {
        public CustomerQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
