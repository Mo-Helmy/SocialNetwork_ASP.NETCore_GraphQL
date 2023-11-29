using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructure.Repositories;
using SocialNetwork.Infrastructure.Repositories.Contract;
using SocialNetwork.Infrastructure.UnitOfWorks;
using SocialNetwork.Infrastructure.UnitOfWorks.Contract;

namespace SocialNetwork.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // Not required as unit of work will generate new object of repository type when needed without using dependency injection.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
