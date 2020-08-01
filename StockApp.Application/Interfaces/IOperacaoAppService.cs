using StockApp.Application.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
	public interface IOperacaoAppService
	{
		Task<IEnumerable<ValidationResult>> CreateAsync(OperacaoDto dto);

		Task DeleteAsync(OperacaoDto dto);

		Task<IEnumerable<ValidationResult>> UpdateAsync(OperacaoDto dto);

		Task<OperacaoDto> GetByIdAsync(int id);

		Task<IEnumerable<OperacaoDto>> GetAllAsync(bool @readonly = false);
	}
}
