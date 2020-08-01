using AutoMapper;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;

namespace StockApp.Application.AutoMapper
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
