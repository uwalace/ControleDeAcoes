using AutoMapper;
using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace StockApp.Services.Api.AutoMapper
{
	public class MappingOperacao : Profile
	{
		public MappingOperacao()
		{
			CreateMap<Operacao, OperacaoDto>()
				.ForMember(dest => dest.Acao, from => from.MapFrom(x => x.Acao))
				.ForMember(dest => dest.Corretora, from => from.MapFrom(x => x.Corretora.Nome))
				.ForMember(dest => dest.Data, from => from.MapFrom(x => x.Data))
				.ForMember(dest => dest.Quantidade, from => from.MapFrom(x => x.Quantidade))
				.ForMember(dest => dest.TipoOperacao, from => from.MapFrom(x => x.TipoOperacao))
				.ForMember(dest => dest.ValorCorretagem, from => from.MapFrom(x => x.ValorCorretagem))
				.ForMember(dest => dest.ValorEmolumento, from => from.MapFrom(x => x.ValorEmolumento))
				.ForMember(dest => dest.ValorLiquidacao, from => from.MapFrom(x => x.ValorLiquidacao))
				.ForMember(dest => dest.ValorTotal, from => from.MapFrom(x => x.ValorTotal))
				.ForMember(dest => dest.ValorUnitario, from => from.MapFrom(x => x.ValorUnitario));

			CreateMap<OperacaoDto, Operacao>()
				.ForMember(dest => dest.AcaoId, from => from.MapFrom(x => x.AcaoId))
				.ForMember(dest => dest.CorretoraId, from => from.MapFrom(x => x.CorretoraId))
				.ForMember(dest => dest.Data, from => from.MapFrom(x => x.Data))
				.ForMember(dest => dest.Quantidade, from => from.MapFrom(x => x.Quantidade))
				.ForMember(dest => dest.TipoOperacao, from => from.MapFrom(x => x.TipoOperacao))
				.ForMember(dest => dest.ValorCorretagem, from => from.MapFrom(x => x.ValorCorretagem))
				.ForMember(dest => dest.ValorEmolumento, from => from.MapFrom(x => x.ValorEmolumento))
				.ForMember(dest => dest.ValorLiquidacao, from => from.MapFrom(x => x.ValorLiquidacao))
				.ForMember(dest => dest.ValorTotal, from => from.MapFrom(x => x.ValorTotal))
				.ForMember(dest => dest.ValorUnitario, from => from.MapFrom(x => x.ValorUnitario));
		}
	}
}
