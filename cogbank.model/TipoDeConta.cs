using Dapper.Contrib.Extensions;
using System;

namespace cogbank.model
{
	[Table("dbo.TiposDeConta")]
	public class TipoDeConta : EntidadeBase
	{
		public TipoDeConta() { }

		public TipoDeConta(Guid id, string descricao)
		{
			this.ID = id;
			this.Descricao = descricao;
		}

		public string Descricao { get; set; }
	}
}
