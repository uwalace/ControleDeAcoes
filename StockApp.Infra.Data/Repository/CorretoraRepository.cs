using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;
using StockApp.Infra.Data.Context;

namespace StockApp.Infra.Data.Repository
{
	public class CorretoraRepository : RepositoryBase<Corretora>, ICorretoraRepository
	{
		public CorretoraRepository(StockContext context) : base(context)
		{

		}

	}
}
