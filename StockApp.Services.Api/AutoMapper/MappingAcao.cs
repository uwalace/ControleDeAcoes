using AutoMapper;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.Threading;

namespace StockApp.Services.Api.AutoMapper
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
