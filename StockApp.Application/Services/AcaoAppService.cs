using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;

namespace StockApp.Application.Services
{
	public class AcaoAppService : AppServiceBase<Acao>, IAcaoAppService
	{
		public AcaoAppService(IAcaoRepository repository) : base(repository)
		{

		}

	}
}
