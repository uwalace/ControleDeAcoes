using StockApp.Domain.Interfaces.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockApp.Domain.Entities
{
	public class Corretora : IEntity
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public double ValorCorretagem { get; set; }
		public float PercentualLiquidacao { get; set; }
		public float PercentualEmolumento { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (String.IsNullOrEmpty(this.Nome)) yield return new ValidationResult("O nome deve ser informado");
		}
	}
}

