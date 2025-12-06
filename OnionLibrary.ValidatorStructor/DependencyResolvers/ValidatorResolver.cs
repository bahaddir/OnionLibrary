using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.ValidatorStructor.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.ValidatorStructor.DependencyResolvers
{
    public static class ValidatorResolver
    {
        public static void AddValidatorService(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AuthorDto>, AuthorValidator>();
            services.AddTransient<IValidator<BookDto>, BookValidator>();
            services.AddTransient<IValidator<TagDto>, TagValidator>();
            services.AddTransient<IValidator<BookTagDto>, BookTagValidator>();
            services.AddTransient<IValidator<CategoryDto>, CategoryValidator>();

        }
    }
}
