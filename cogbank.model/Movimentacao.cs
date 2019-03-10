using Dapper.Contrib.Extensions;
using System;

namespace cogbank.model
{
	[Table("dbo.Movimentacoes")]
	public class Movimentacao : EntidadeBase
	{
		public Movimentacao() { }

		public Movimentacao(Guid id, Guid tipoDeMovimentacaoID, decimal valor, DateTime dataDaMovimentacao, Guid contaID)
		{
			ID = id;
			TipoDeMovimentacaoID = tipoDeMovimentacaoID;
			Valor = valor;
			DataDaMovimentacao = dataDaMovimentacao;
			ContaID = contaID;
		}

		public Guid TipoDeMovimentacaoID { get; set; }

		public decimal Valor { get; set; }

		public DateTime DataDaMovimentacao { get; set; }

		public Guid ContaID { get; set; }

		[Write(false)]
		public Conta Conta { get; set; }

		[Write(false)]
		public TipoDeMovimentacao TipoDeMovimentacao { get; set; }
	}
}
