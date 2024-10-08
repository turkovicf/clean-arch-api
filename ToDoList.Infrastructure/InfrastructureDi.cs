using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Infrastructure
{
    public static class InfrastructureDi
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IToDoRepository, ToDoRepository>();

            return services;
        }
    }
}
