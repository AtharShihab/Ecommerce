using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Core.Repositories.Command;
using Ordering.Core.Repositories.Command.Base;
using Ordering.Core.Repositories.Query;
using Ordering.Core.Repositories.Query.Base;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Identity;
using Ordering.Infrastructure.Repositories.Command;
using Ordering.Infrastructure.Repositories.Command.Base;
using Ordering.Infrastructure.Repositories.Query;
using Ordering.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderingContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(OrderingContext).FullName)));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<OrderingContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                // Default Lockout Settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default Password Settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false; // special character
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Default SignIn Settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });


            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();

            return services;
        }
    }
}
