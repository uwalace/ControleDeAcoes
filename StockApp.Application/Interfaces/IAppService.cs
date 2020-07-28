using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StockApp.Application.Interfaces
{
	public interface IAppService<TEntity> where TEntity : class
	{
		IEnumerable<ValidationResult> Create(TEntity entity);

		void Delete(int id);

		IEnumerable<ValidationResult> Update(TEntity entity);

		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll(bool @readonly = false);

		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
	}
}
