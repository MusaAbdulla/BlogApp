﻿using BlogApp.Core.Repositories;
using BlogApp.DAL.Repositeries;
using BlogApp.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepostory, CategoryRepository>();
            services.AddScoped<IUserRepositories, UserRepository>();
            return services;
        }
    }
}
