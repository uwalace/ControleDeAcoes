using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;

namespace StockApp.Application.Services
{
	public class OperacaoAppService : AppServiceBase<Operacao>, IOperacaoAppService
	{		
		public OperacaoAppService(IOperacaoRepository repository) : base(repository)
		{
			
		}

	}
}
