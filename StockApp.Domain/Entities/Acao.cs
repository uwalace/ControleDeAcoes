using StockApp.Domain.Interfaces.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockApp.Domain.Entities
{
	public class Acao : IEntity
	{
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (String.IsNullOrEmpty(this.Codigo)) yield return new ValidationResult("O código deve ser informado");
			if(String.IsNullOrEmpty( this.Descricao)) yield return new ValidationResult("A descrição deve ser informada");
		}
	}
}
