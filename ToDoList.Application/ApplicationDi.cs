using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services.ToDoService;

namespace ToDoList.Application
{
    public static class ApplicationDi
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        { 
            services.AddScoped<IToDoService, ToDoService>();

            return services;
        }
    }
}
