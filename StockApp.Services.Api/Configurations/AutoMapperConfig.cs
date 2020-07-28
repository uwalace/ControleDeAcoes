using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Services.Api.AutoMapper;

namespace StockApp.Services.Api.Configurations
{
	public static class AutoMapperConfig
	{
		public static void AddMapper(this IServiceCollection services)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingAcao());
				mc.AddProfile(new MappingCorretora());
				mc.AddProfile(new MappingOperacao());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

	}
}
