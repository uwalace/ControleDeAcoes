using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Infra.CrossCutting.IoC;

namespace StockApp.Services.Api.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			ConfigurationIoC.AddServices(services, configuration, "DefaultConnection");
		}
	}
}
