using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public IEnumerable<CorretoraDto> Get()
		{
			var ret = _mapper.Map<IEnumerable<CorretoraDto>>(_service.GetAll());
			return ret;
		}

		[HttpGet("corretora/{id:int}")]
		public CorretoraDto GetById(int id)
		{
			return _mapper.Map<CorretoraDto>(_service.GetById(id));
		}

		[HttpPost("corretora/create")]
		public IEnumerable<ValidationResult> Create([FromBody] CorretoraDto model)
		{
			var entity = _mapper.Map<Corretora>(model);
			var validationResult = _service.Create(entity);

			return validationResult;
		}

		[HttpPut("corretora/update")]
		public IEnumerable<ValidationResult> Update([FromBody] CorretoraDto model)
		{
			var entity = _mapper.Map<Corretora>(model);
			_service.Update(entity);

			return _service.Update(entity);
		}

		[HttpDelete("corretora/delete/{id:int}")]
		public ActionResult<string> Delete(int id)
		{
			_service.Delete(id);

			return base.Ok();
		}
	}
}
