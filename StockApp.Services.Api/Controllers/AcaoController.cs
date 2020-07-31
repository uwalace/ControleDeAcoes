using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StockApp.Services.Api.Controllers
{
	[Route("api")]
	[ApiController]
	public class AcaoController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAcaoAppService _service;

		public AcaoController(IAcaoAppService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet("Acao")]
		public async Task<IEnumerable<AcaoDto>> GetAsync()
		{
			var ret = _mapper.Map<IEnumerable<AcaoDto>>(await _service.GetAllAsync());
			return ret;
		}

		[HttpGet("Acao/{id:int}")]
		public async Task<AcaoDto> GetByIdAsync(int id)
		{
			return _mapper.Map<AcaoDto>(await _service.GetByIdAsync(id));
		}

		[HttpPost("Acao/Create")]
		public async Task<IEnumerable<ValidationResult>> CreateAsync([FromBody] AcaoDto model)
		{
			var entity = _mapper.Map<Acao>(model);
			var validationResult = await _service.CreateAsync(entity);

			return validationResult;
		}

		[HttpPut("Acao/Update")]
		public async Task<IEnumerable<ValidationResult>> UpdateAsync([FromBody] AcaoDto model)
		{
			var entity = _mapper.Map<Acao>(model);

			return await _service.UpdateAsync(entity);
		}

		[HttpDelete("Acao/Delete/{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var entity = await _service.GetByIdAsync(id);
			if (entity != null)
			{
				_service.DeleteAsync(entity);
				return Ok();
			}
			else
				return NotFound();

		}
	}
}
