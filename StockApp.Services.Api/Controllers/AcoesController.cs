using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace StockApp.Services.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AcoesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAcaoAppService _service;

		public AcoesController(IAcaoAppService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(_mapper.Map<IEnumerable<AcaoDto>>(await _service.GetAllAsync()));
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			return Ok(_mapper.Map<AcaoDto>(await _service.GetByIdAsync(id)));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] AcaoDto model)
		{
			var validationResult = await _service.CreateAsync(model);

			if (validationResult.Any())
				return BadRequest(validationResult);
			else
				return Created("", model);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync([FromBody] AcaoDto model)
		{
			var validationResult = await _service.UpdateAsync(model);

			if (validationResult.Any())
				return BadRequest(validationResult);
			else
				return NoContent();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var entity = await _service.GetByIdAsync(id);
			if (entity != null)
			{
				await _service.DeleteAsync(entity);
				return NoContent();
			}
			else
				return NotFound(id);

		}
	}
}
