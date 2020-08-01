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
	public class CorretoraAppService : ICorretoraAppService
	{
		private readonly ICorretoraRepository _repository;
		private readonly IMapper _mapper;
		public CorretoraAppService(ICorretoraRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<ValidationResult>> CreateAsync(CorretoraDto dto)
		{
			return await _repository.CreateAsync(_mapper.Map<Corretora>(dto));
		}

		public async Task DeleteAsync(CorretoraDto dto)
		{
			await _repository.DeleteAsync(_mapper.Map<Corretora>(dto));
		}

		public void Dispose()
		{
			//_repository.dis;
		}

		public async Task<IEnumerable<CorretoraDto>> GetAllAsync(bool @readonly = false)
		{
			return _mapper.Map<IEnumerable<CorretoraDto>>(await _repository.GetAllAsync());
		}

		public async Task<CorretoraDto> GetByIdAsync(int id)
		{
			return _mapper.Map<CorretoraDto>(await _repository.GetByIdAsync(id));
		}

		public async Task<IEnumerable<ValidationResult>> UpdateAsync(CorretoraDto dto)
		{
			return await _repository.UpdateAsync(_mapper.Map<Corretora>(dto));
		}
	}
}
