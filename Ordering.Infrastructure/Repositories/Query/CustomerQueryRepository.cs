using Dapper;
using Microsoft.Extensions.Configuration;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;
using Ordering.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Query
{
    public class CustomerQueryRepository : QueryRepository<Customer>,ICustomerQueryRepository
    {
        public CustomerQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Customer>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Customer>(query,parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            try
            {
                var query = "SELECT * FROM CUSTOMERS WHERE Email = @Email";
                var parameters = new DynamicParameters();
                parameters.Add("Email", email, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            throw new NotImplementedException();
        }
    }
}
