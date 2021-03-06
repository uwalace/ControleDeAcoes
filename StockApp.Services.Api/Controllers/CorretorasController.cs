﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Dto;
using StockApp.Application.Interfaces;
using StockApp.Domain.Entities;

namespace StockApp.Services.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CorretorasController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICorretoraAppService _service;

		public CorretorasController(ICorretoraAppService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(_mapper.Map<IEnumerable<CorretoraDto>>(await _service.GetAllAsync()));			
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			return Ok(_mapper.Map<CorretoraDto>(await _service.GetByIdAsync(id)));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CorretoraDto model)
		{
			var validationResult = await _service.CreateAsync(model);

			if (validationResult.Any())
				return BadRequest(validationResult);
			else
				return Created("", model);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync([FromBody] CorretoraDto model)
		{
			var validationResult = await _service.UpdateAsync(model);

			if (validationResult.Any())
				return BadRequest(validationResult);
			else
				return NoContent();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var entity = await _service.GetByIdAsync(id);
			if (entity != null)
			{
				await _service.DeleteAsync(entity);
				return Ok();
			}
			else
				return NotFound();
		}
	}
}
