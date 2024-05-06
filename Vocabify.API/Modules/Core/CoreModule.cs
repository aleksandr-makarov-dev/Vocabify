namespace Vocabify.API.Modules.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddExceptionHandler<ExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
