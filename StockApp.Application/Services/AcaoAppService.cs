using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using StockApp.Application.Dto;

namespace StockApp.Application.Services
{
	public class AcaoAppService : IAcaoAppService
	{
		private readonly IAcaoRepository _repository;
		private readonly IMapper _mapper;
			public AcaoAppService(IAcaoRepository repository, IMapper mapper) 
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ValidationResult>> CreateAsync(AcaoDto dto)
		{
			return await _repository.CreateAsync(_mapper.Map<Acao>(dto));
		}

		public async Task DeleteAsync(AcaoDto dto)
		{
			await _repository.DeleteAsync(_mapper.Map<Acao>(dto));
		}

		public void Dispose()
		{
			//_repository.dis;
		}

		public async Task<IEnumerable<AcaoDto>> GetAllAsync(bool @readonly = false)
		{
			return _mapper.Map<IEnumerable<AcaoDto>>(await _repository.GetAllAsync());
		}

		public async Task<AcaoDto> GetByIdAsync(int id)
		{
			return _mapper.Map<AcaoDto>(await _repository.GetByIdAsync(id));
		}

		public async Task<IEnumerable<ValidationResult>> UpdateAsync(AcaoDto dto)
		{
			return await _repository.UpdateAsync(_mapper.Map<Acao>(dto));
		}
	}
}
