using ToDoList.Application;
using ToDoList.Infrastructure;

namespace ToDoList.Api
{
    public static class ApiDi
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration) {
            services.AddApplicationDI().AddInfrastructureDI(configuration);
            
            return services;
        }
    }
}
