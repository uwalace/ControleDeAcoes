using AutoMapper;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.Threading;

namespace StockApp.Services.Api.AutoMapper
{
	public class MappingCorretora : Profile
	{
		public MappingCorretora()
		{
			CreateMap<Corretora, CorretoraDto>();
			CreateMap<CorretoraDto, Corretora>();
		}
	}
}
