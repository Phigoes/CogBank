using cogbank.gerenciador;
using System;
using System.Collections.Generic;

namespace cogbank.staticlist
{
	public class TiposDeMovimentacao
	{
		public string Nome { get; set; }
		public Guid Valor { get; set; }

		public static IEnumerable<TiposDeMovimentacao> ObterTiposDeMovimentacao()
		{
			yield return new TiposDeMovimentacao { Nome = "Crédito", Valor = GerenciadorDeTiposDeMovimentacao.Credito };
			yield return new TiposDeMovimentacao { Nome = "Débito", Valor = GerenciadorDeTiposDeMovimentacao.Debito };
		}
	}
}
