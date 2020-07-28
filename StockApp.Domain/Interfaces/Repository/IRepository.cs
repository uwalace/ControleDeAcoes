using StockApp.Domain.Interfaces.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace StockApp.Domain.Interfaces.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : class
	{
		IEnumerable<ValidationResult> Create(TEntity entity);

		void Delete(TEntity entity);

		IEnumerable<ValidationResult> Update(TEntity entity);

		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll(bool @readonly = false);

		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
	}
}
