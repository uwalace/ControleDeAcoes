using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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
		public IEnumerable<AcaoDto> Get()
		{
			var ret = _mapper.Map<IEnumerable<AcaoDto>>(_service.GetAll());
			return ret;
		}

		[HttpGet("Acao/{id:int}")]
		public AcaoDto GetById(int id)
		{
			return _mapper.Map<AcaoDto>(_service.GetById(id));
		}

		[HttpPost("Acao/Create")]
		public IEnumerable<ValidationResult> Create([FromBody] AcaoDto model)
		{
			var entity = _mapper.Map<Acao>(model);
			var validationResult = _service.Create(entity);

			return validationResult;
		}

		[HttpPut("Acao/Update")]
		public IEnumerable<ValidationResult> Update([FromBody] AcaoDto model)
		{
			var entity = _mapper.Map<Acao>(model);
			_service.Update(entity);

			return _service.Update(entity);
		}

		[HttpDelete("Acao/Delete/{id:int}")]
		public ActionResult<string> Delete(int id)
		{
			_service.Delete(id);

			return base.Ok();
		}
	}
}
