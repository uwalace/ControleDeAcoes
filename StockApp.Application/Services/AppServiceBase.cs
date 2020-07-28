using StockApp.Application.Interfaces;
using StockApp.Domain.Interfaces.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace StockApp.Application.Services
{
	public class AppServiceBase<TEntity> : IAppService<TEntity> where TEntity : class
	{
		private readonly IRepository<TEntity> _repository;
		public AppServiceBase(IRepository<TEntity> repository)
		{
			_repository = repository;
		}
		public IEnumerable<ValidationResult> Create(TEntity entity)
		{
			return _repository.Create(entity);
		}

		public void Delete(int id)
		{
			_repository.Delete(_repository.GetById(id));
		}

		public void Dispose()
		{
			//_repository.dis;
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> GetAll(bool @readonly = false)
		{
			return  _repository.GetAll();
		}

		public TEntity GetById(int id)
		{
			return _repository.GetById(id);
		}

		public IEnumerable<ValidationResult> Update(TEntity entity)
		{
			return _repository.Update(entity);
		}
	}
}
