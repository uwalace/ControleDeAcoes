using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;

namespace StockApp.Infra.Data.Context
{
	public class StockContext : DbContext//, IUnitOfWork
	{
		public StockContext(DbContextOptions<StockContext> option) : base(option)
		{

		}

		public DbSet<Acao> Acoes { get; set; }
		public DbSet<Corretora> Corretoras { get; set; }
		public DbSet<Operacao> Operacoes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Ignore<ValidationResult>();

			modelBuilder.Entity<Acao>().HasKey(a => a.Id);
			modelBuilder.Entity<Corretora>().HasKey(a => a.Id);
			modelBuilder.Entity<Operacao>().HasKey(a => a.Id);
		}

	}

	
}
