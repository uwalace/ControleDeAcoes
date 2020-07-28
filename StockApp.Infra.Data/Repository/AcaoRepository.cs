
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;
using StockApp.Infra.Data.Context;

namespace StockApp.Infra.Data.Repository
{
	public class AcaoRepository : RepositoryBase<Acao>, IAcaoRepository
	{
		public AcaoRepository(StockContext context) : base(context)
		{

		}
		
	}
}
