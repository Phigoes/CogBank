using cogbank.data.Base;
using cogbank.helper.Attributes;
using cogbank.model;
using cogbank.model.Interfaces.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cogbank.data.Repository
{
	[InterfaceMapping("IMovimentacaoRepository")]
	public class MovimentacaoRepository : RepositoryBase<Movimentacao>, IMovimentacaoRepository
	{
		public IEnumerable<Movimentacao> ObterMovimentacoesDaConta(Guid id)
		{
			string query = "     Select * "
						 + "       From [dbo].[Movimentacoes] a "
						 + " Inner Join [dbo].[Contas] b "
						 + "         On b.ID = a.ContaID "
						 + " Inner Join [dbo].[TiposDeMovimentacao] c "
						 + "         On c.ID = a.TipoDeMovimentacaoID "
						 + "      Where b.ID = @ID";

			return base.conn.Query<Movimentacao, ContaCorrente, TipoDeMovimentacao, Movimentacao>
				(query, (movimentacao, contaCorrente, tipoDeMovimentacao) =>
				{
					movimentacao.Conta = contaCorrente;
					movimentacao.TipoDeMovimentacao = tipoDeMovimentacao;

					return movimentacao;

				}, new { ID = id }).ToList();
		}
	}
}
