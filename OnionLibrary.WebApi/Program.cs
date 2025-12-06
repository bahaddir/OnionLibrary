using OnionLibrary.Application.DependencyResolvers;
using OnionLibrary.InnerInfrastructure.DependencyResolvers;
using OnionLibrary.Persistence.DependencyResolvers;
using OnionLibrary.WebApi.DependencyResolvers;
using OnionLibrary.ValidatorStructor.DependencyResolvers;
namespace OnionLibrary.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContextService();
            builder.Services.AddRepositoryService();
            builder.Services.AddManagerService();
            builder.Services.AddDtoMapperService();
            builder.Services.AddVmMapperService();
            builder.Services.AddValidatorService();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
