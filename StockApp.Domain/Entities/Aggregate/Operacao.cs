using StockApp.Domain.Interfaces.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Domain.Entities
{
	public class Operacao : IEntity
	{
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public Acao Acao { get; set; }
		public int AcaoId { get; set; }
		public int Quantidade { get; set; }
		public double ValorUnitario { get; set; }
		public double ValorCorretagem { get; set; }
		public double ValorEmolumento { get; set; }
		public double ValorLiquidacao { get; set; }
		public double ValorTotal { get; set; }
		public Corretora Corretora { get; set; }
		public int CorretoraId { get; set; }
		public TipoOperacao TipoOperacao { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(ValorTotal != ((ValorUnitario * Quantidade) +
							 ValorCorretagem + 
							 ValorEmolumento +
							 ValorLiquidacao)) yield return new ValidationResult("A soma dos valores de corretagem," +
																				 "emolumento, liquidacao e valor unitario " + 
																				 "multiplacado pela valor unitario não correspondem");

			if (Data == DateTime.MinValue) yield return new ValidationResult("A Data não pode ser nula");

			if (AcaoId == int.MinValue) yield return new ValidationResult("A Acão não pode ser nula");

			if (Quantidade <= 0) yield return new ValidationResult("A quantidade de ser maior que zero");

			if (ValorUnitario <= 0) yield return new ValidationResult("O valor unitário deve ser maior que zero");

			if (CorretoraId == int.MinValue) yield return new ValidationResult("A corretora não pode ser nula");
		}

	}
}
