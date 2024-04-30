using Vocabify.API.Modules.Terms.Services;

namespace Vocabify.API.Modules.Terms
{
    public static class TermsModule
    {
        public static IServiceCollection AddTermsModule(this IServiceCollection services)
        {
            services.AddScoped<ITermsService, TermsService>();

            return services;
        }
    }
}
