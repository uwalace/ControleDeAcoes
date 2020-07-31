using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
	public interface IAppService<TEntity> where TEntity : class
	{
		Task<IEnumerable<ValidationResult>> CreateAsync(TEntity entity);

		void DeleteAsync(TEntity entity);

		Task<IEnumerable<ValidationResult>> UpdateAsync(TEntity entity);

		Task<TEntity> GetByIdAsync(int id);

		Task<IEnumerable<TEntity>> GetAllAsync(bool @readonly = false);

		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
	}
}
