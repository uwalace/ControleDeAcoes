using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using StockApp.Infra.Data.Context;
using StockApp.Domain.Interfaces.Repository;
using System.Linq.Expressions;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Infra.Data.Repository
{
	public class RepositoryBase<TEntity> : IRepository<TEntity>
			where TEntity : class
	{
		private readonly StockContext _context;//gerar interface
		private readonly DbSet<TEntity> DbSet;

		public RepositoryBase(StockContext context)
		{
			_context = context;
			DbSet = _context.Set<TEntity>();
		}

		public IEnumerable<ValidationResult> Create(TEntity entity)
		{
			DbSet.Add(entity);
			return this.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			DbSet.Remove(entity);
			_context.SaveChanges();
		}
				
		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
		{
			return @readonly
				? DbSet.AsNoTracking().Where(predicate).ToList()
				: DbSet.Where(predicate).ToList();
		}

		public IEnumerable<TEntity> GetAll( bool @readonly = false)
		{
			return @readonly
				? DbSet.AsNoTracking().ToList()
				: DbSet.ToList();
		}

		public TEntity GetById(int id)
		{
			return DbSet.Find(id);
		}

		public virtual IEnumerable<ValidationResult> Update(TEntity entity)
		{
			var entry = _context.Entry(entity);
			DbSet.Attach(entity);
			entry.State = EntityState.Modified;

			return this.SaveChanges();
		}

		private IEnumerable<ValidationResult> SaveChanges()
		{
			var validationErrors = _context.ChangeTracker
			.Entries<IValidatableObject>()
			.SelectMany(e => e.Entity.Validate(null))
			.Where(r => r != ValidationResult.Success);

			if (!validationErrors.Any())
			_context.SaveChanges();

			return validationErrors;
		}

		public void Dispose()
		{
			if(_context != null) _context.Dispose();
		}
	}
}
