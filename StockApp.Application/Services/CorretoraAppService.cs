using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;

namespace StockApp.Application.Services
{
	public class CorretoraAppService : AppServiceBase<Corretora>, ICorretoraAppService
	{
		public CorretoraAppService(ICorretoraRepository repository) : base(repository)
		{
		}
	}
}
