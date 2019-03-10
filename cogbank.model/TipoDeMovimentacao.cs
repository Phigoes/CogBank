using Dapper.Contrib.Extensions;
using System;

namespace cogbank.model
{
	[Table("dbo.TiposDeMovimentacao")]
	public class TipoDeMovimentacao : EntidadeBase
	{
		public TipoDeMovimentacao() { }

		public TipoDeMovimentacao(Guid id, string descricao)
		{
			this.ID = id;
			this.Descricao = descricao;
		}

		public string Descricao { get; set; }
	}
}
