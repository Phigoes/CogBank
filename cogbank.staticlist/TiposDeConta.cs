using cogbank.gerenciador;
using System;
using System.Collections.Generic;

namespace cogbank.staticlist
{
	public class TiposDeConta
	{
		public string Nome { get; set; }
		public Guid Valor { get; set; }

		public static IEnumerable<TiposDeConta> ObterTiposDeConta()
		{
			yield return new TiposDeConta { Nome = "Conta Corrente", Valor = GerenciadorDeTiposDeConta.ContaCorrente };
		}
	}
}
