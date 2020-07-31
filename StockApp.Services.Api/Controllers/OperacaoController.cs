using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Dto;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;

namespace StockApp.Services.Api.Controllers
{
	[Route("api")]
	[ApiController]
	public class OperacaoController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IOperacaoAppService _service;

		public OperacaoController(IOperacaoAppService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet("operacao")]
		public async Task<IEnumerable<OperacaoDto>> GetAsync()
		{
			var ret = _mapper.Map<IEnumerable<OperacaoDto>>(await _service.GetAllAsync());
			return ret;
		}

		[HttpGet("operacao/{id:int}")]
		public async Task<OperacaoDto> GetByIdAsync(int id)
		{
			return _mapper.Map<OperacaoDto>(await _service.GetByIdAsync(id));
		}

		[HttpPost("operacao/create")]
		public async Task<IEnumerable<ValidationResult>> CreateAsync([FromBody] OperacaoDto model)
		{
			var entity = _mapper.Map<Operacao>(model);
			return await _service.CreateAsync(entity);
		}

		[HttpPut("operacao/update")]
		public async Task<IEnumerable<ValidationResult>> UpdateAsync([FromBody] OperacaoDto model)
		{
			var entity = _mapper.Map<Operacao>(model);

			return await _service.UpdateAsync(entity);
		}

		[HttpDelete("operacao/delete/{id:int}")]
		public async Task<IActionResult> RemoveAsync(int id)
		{
			var entity = await _service.GetByIdAsync(id);
			if (entity != null)
			{
				_service.DeleteAsync(entity);
				return Ok();
			}
			else
				return NotFound(id);
		}
	}
}
