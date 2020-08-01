using StockApp.Application.Dto;
using StockApp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StockApp.Application.Interfaces
{
	public interface ICorretoraAppService
	{
		Task<IEnumerable<ValidationResult>> CreateAsync(CorretoraDto dto);

		Task DeleteAsync(CorretoraDto dto);

		Task<IEnumerable<ValidationResult>> UpdateAsync(CorretoraDto dto);

		Task<CorretoraDto> GetByIdAsync(int id);

		Task<IEnumerable<CorretoraDto>> GetAllAsync(bool @readonly = false);
	}
}
