using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Dto;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;

namespace StockApp.Services.Api.Controllers
{
	[Route("api")]
	[ApiController]
	public class CorretoraController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICorretoraAppService _service;

		public CorretoraController(ICorretoraAppService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet("corretora")]
		public async Task<IEnumerable<CorretoraDto>> GetAsync()
		{
			var ret = _mapper.Map<IEnumerable<CorretoraDto>>(await _service.GetAllAsync());
			return ret;
		}

		[HttpGet("corretora/{id:int}")]
		public async Task<CorretoraDto> GetByIdAsync(int id)
		{
			return _mapper.Map<CorretoraDto>(await _service.GetByIdAsync(id));
		}

		[HttpPost("corretora/create")]
		public async Task<IEnumerable<ValidationResult>> CreateAsync([FromBody] CorretoraDto model)
		{
			var entity = _mapper.Map<Corretora>(model);
			var validationResult = await _service.CreateAsync(entity);

			return validationResult;
		}

		[HttpPut("corretora/update")]
		public async Task<IEnumerable<ValidationResult>> UpdateAsync([FromBody] CorretoraDto model)
		{
			var entity = _mapper.Map<Corretora>(model);

			return await _service.UpdateAsync(entity);
		}

		[HttpDelete("corretora/delete/{id:int}")]
		public async Task<IActionResult> Delete(int id)
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
