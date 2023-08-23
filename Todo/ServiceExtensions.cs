using Todo.Middlewares;

namespace Todo
{
    public static class ServiceExtensions
    {
        public static IServiceCollection PresentationServices(this IServiceCollection services)
        {
            services.AddTransient<GlobalErrorHandlerMiddleware>();

            return services;
        }
    }
}
