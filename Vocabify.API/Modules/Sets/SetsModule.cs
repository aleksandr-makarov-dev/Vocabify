using Vocabify.API.Modules.Sets.Services;

namespace Vocabify.API.Modules.Sets
{
    public static class SetsModule
    {
        public static IServiceCollection AddSetsModule(this IServiceCollection services)
        {
            services.AddScoped<ISetsService, SetsService>();
            services.AddScoped<IImportService, ImportService>();

            return services;
        }
    }
}
