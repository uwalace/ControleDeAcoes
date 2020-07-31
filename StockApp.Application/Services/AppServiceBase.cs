using StockApp.Application.Interfaces;
using StockApp.Domain.Interfaces.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
	public class AppServiceBase<TEntity> : IAppService<TEntity> where TEntity : class
	{
		private readonly IRepository<TEntity> _repository;
		public AppServiceBase(IRepository<TEntity> repository)
		{
			_repository = repository;
		}
		public async Task<IEnumerable<ValidationResult>> CreateAsync(TEntity entity)
		{
			return await _repository.CreateAsync(entity);
		}

		public void DeleteAsync(TEntity entity)
		{			
			_repository.DeleteAsync(entity);
		}

		public void Dispose()
		{
			//_repository.dis;
		}

		public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
		{
			return await _repository.FindAsync(predicate, @readonly);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync(bool @readonly = false)
		{
			return await  _repository.GetAllAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<ValidationResult>> UpdateAsync(TEntity entity)
		{
			return await _repository.UpdateAsync(entity);
		}
	}
}
