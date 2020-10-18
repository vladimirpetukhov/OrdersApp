using AutoMapper;
using Server.API.Data;
using Server.API.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Infrastructure.Extensions
{
    public static class RepositoryCollectionsExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
           => services
                .AddScoped<IAuthRepository, AuthRepository>()
                .AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>))
                .AddScoped<IDatingRepository, DatingRepository>()
                .AddAutoMapper(typeof(DatingRepository).Assembly)
                .AddTransient<Seed>()
                .AddScoped<LogUserActivity>();
    }
}
