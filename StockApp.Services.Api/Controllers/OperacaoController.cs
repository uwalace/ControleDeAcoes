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
		public IEnumerable<OperacaoDto> Get()
		{
			var ret = _mapper.Map<IEnumerable<OperacaoDto>>(_service.GetAll());
			return ret;
		}

		[HttpGet("operacao/{id:int}")]
		public OperacaoDto GetById(int id)
		{
			return _mapper.Map<OperacaoDto>(_service.GetById(id));
		}

		[HttpPost("operacao/create")]
		public IEnumerable<ValidationResult> Create([FromBody] OperacaoDto model)
		{
			var entity = _mapper.Map<Operacao>(model);
			return _service.Create(entity);
		}

		[HttpPut("operacao/update")]
		public IEnumerable<ValidationResult> Update([FromBody] OperacaoDto model)
		{
			var entity = _mapper.Map<Operacao>(model);
			_service.Update(entity);

			return _service.Update(entity);
		}

		[HttpDelete("operacao/delete/{id:int}")]
		public ActionResult<string> Remove(int id)
		{
			_service.Delete(id);

			return base.Ok();
		}
	}
}
