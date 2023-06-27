using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Common.Interfaces;
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
using Ordering.Infrastructure.Services;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<OrderingContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(OrderingContext).FullName)));
            //services.AddDbContext<OrderingContext>(options => options.UseSqlite("name=ConnectionStrings:DefaultConnection"));
            services.AddDbContext<OrderingContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<OrderingContext>().AddDefaultTokenProviders();

            //var jwtSettings = new JwtSettings();
            //services.Configure<JwtSettings>(options => configuration.GetSection(JwtSettings.SectionName));
            // Bind JwtSettings


            services.Configure<IdentityOptions>(options =>
            {
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


            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddTransient<IOrderMasterCommandRepository, OrderMasterCommandRepository>();
            services.AddTransient<IOrderDetailCommandRepository, OrderDetailCommandRepository>();
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddTransient<IOrderMasterQueryRepository, OrderMasterQueryRepository>();

            return services;
        }
    }
}
