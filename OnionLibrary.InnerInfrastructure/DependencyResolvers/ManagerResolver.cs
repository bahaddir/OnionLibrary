using Microsoft.Extensions.DependencyInjection;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.InnerInfrastructure.ManagerConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.InnerInfrastructure.DependencyResolvers
{
    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorManager, AuthorManager>();
            services.AddScoped<IBookManager, BookManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ITagManager, TagManager>();
            services.AddScoped<IBookTagManager, BookTagManager>();
        }
    }
}
