using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;
using StockApp.Infra.Data.Context;

namespace StockApp.Infra.Data.Repository
{
	public class OperacaoRepository: RepositoryBase<Operacao>, IOperacaoRepository
	{
		public OperacaoRepository(StockContext context) : base(context)
		{

		}
	}
}
