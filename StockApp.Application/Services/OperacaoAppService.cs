using AutoMapper;
using StockApp.Application.Dto;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
	public class OperacaoAppService : IOperacaoAppService
	{
		private readonly IOperacaoRepository _repository;
		private readonly IMapper _mapper;
		public OperacaoAppService(IOperacaoRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<ValidationResult>> CreateAsync(OperacaoDto dto)
		{
			var entity = _mapper.Map<Operacao>(dto);
			return await _repository.CreateAsync(entity);
		}

		public async Task DeleteAsync(OperacaoDto dto)
		{
			var entity = _mapper.Map<Operacao>(dto);
			await _repository.DeleteAsync(entity);
		}

		public void Dispose()
		{
			//_repository.dis;
		}

		public async Task<IEnumerable<OperacaoDto>> GetAllAsync(bool @readonly = false)
		{			
			return  _mapper.Map<IEnumerable<OperacaoDto>>(await _repository.GetAllAsync());
		}

		public async Task<OperacaoDto> GetByIdAsync(int id)
		{
			return _mapper.Map<OperacaoDto>(await _repository.GetByIdAsync(id));
		}

		public async Task<IEnumerable<ValidationResult>> UpdateAsync(OperacaoDto dto)
		{
			return await _repository.UpdateAsync(_mapper.Map<Operacao>(dto));
		}

	}
}
