using Dapper.Contrib.Extensions;
using System;

namespace cogbank.model
{
	[Table("dbo.Contas")]
	public class ContaCorrente : Conta
	{
		public ContaCorrente() { }

		public ContaCorrente(Guid id, int numero, string nomeDoTitular, decimal saldo, Guid tipoDeContaID)
			: base(id, numero, nomeDoTitular, saldo)
		{
			ID = id;
			Numero = numero;
			NomeDoTitular = nomeDoTitular;
			Saldo = saldo;
			TipoDeContaID = tipoDeContaID;
		}

		public Guid TipoDeContaID { get; set; }

		[Write(false)]
		public TipoDeConta TipoDeConta { get; set; }
	}
}
