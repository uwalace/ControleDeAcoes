using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using StockApp.Domain.Interfaces.Repository;
using StockApp.Infra.Data.Context;
using StockApp.Infra.Data.Repository;

namespace StockApp.Infra.CrossCutting.IoC
{
	public static class ConfigurationIoC
	{

		public static void AddServices(IServiceCollection services, IConfiguration configuration, string connectionStringName)
		{
			services.AddDbContext<StockContext>(option =>
				option.UseSqlServer(configuration.GetConnectionString(connectionStringName),
				x => x.MigrationsAssembly("StockApp.Infra.Data")));

			//Stock.Infra.Data
			services.AddScoped<IAcaoRepository, AcaoRepository>();
			services.AddScoped<ICorretoraRepository, CorretoraRepository>();
			services.AddScoped<IOperacaoRepository, OperacaoRepository>();

			//Stock.Application
			services.AddScoped<ICorretoraAppService, CorretoraAppService>();			
			services.AddScoped<IAcaoAppService, AcaoAppService>();
			services.AddScoped<IOperacaoAppService, OperacaoAppService>();

		}

	}
}
