using Challenge.ApplicationService.Services;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Repositories;
using Challenge.Infra.Data.Repositories;

namespace Challenge.Presentation.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            //Configure dependencies
            services.AddTransient<IImporterApplicationService, ImporterApplicationService>();
            services.AddTransient<IMerchantRepository, MerchantRepository>();
        }
    }
}
