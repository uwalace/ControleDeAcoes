using AutoMapper;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;

namespace StockApp.Application.AutoMapper
{
	public class MappingAcao : Profile
	{
		public MappingAcao()
		{
			CreateMap<Acao, AcaoDto>();
			CreateMap<AcaoDto, Acao>();
		}
	}
}
