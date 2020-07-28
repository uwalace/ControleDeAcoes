using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp.Application.Dto
{
	public class CorretoraDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public double ValorCorretagem { get; set; }
		public float PercentualLiquidacao { get; set; }
		public float PercentualEmolumento { get; set; }
	}
}
