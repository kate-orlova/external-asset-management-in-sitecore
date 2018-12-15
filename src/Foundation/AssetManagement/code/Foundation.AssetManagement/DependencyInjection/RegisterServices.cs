using Foundation.AssetManagement.Interfaces;
using Foundation.AssetManagement.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Foundation.AssetManagement.DependencyInjection
{
    public class RegisterServices : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IExternalService, ExternalService>();
            serviceCollection.AddScoped<IExternalImageProcessor, ExternalImageProcessor>();
        }
    }
}