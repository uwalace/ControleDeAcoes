using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp.Application.Dto
{
	public class OperacaoDto
	{

		public int Id { get; set; }
		public DateTime Data { get; set; }
		public int AcaoId { get; set; }
		public string Acao { get; set; }
		public int Quantidade { get; set; }
		public double ValorUnitario { get; set; }
		public double ValorCorretagem { get; set; }
		public double ValorEmolumento { get; set; }
		public double ValorLiquidacao { get; set; }
		public double ValorTotal { get; set; }
		public string Corretora { get; set; }
		public int CorretoraId { get; set; }
		public string TipoOperacao { get; set; }
	}
}
