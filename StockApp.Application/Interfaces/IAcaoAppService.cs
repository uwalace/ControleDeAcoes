using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
	public interface IAcaoAppService
	{
		Task<IEnumerable<ValidationResult>> CreateAsync(AcaoDto dto);

		Task DeleteAsync(AcaoDto dto);

		Task<IEnumerable<ValidationResult>> UpdateAsync(AcaoDto dto);

		Task<AcaoDto> GetByIdAsync(int id);

		Task<IEnumerable<AcaoDto>> GetAllAsync(bool @readonly = false);
	}
}
