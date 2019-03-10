using cogbank.data.Base;
using cogbank.helper.Attributes;
using cogbank.model;
using cogbank.model.Interfaces.Repository;
using Dapper;
using System.Collections.Generic;

namespace cogbank.data.Repository
{
	[InterfaceMapping("IContaCorrenteRepository")]
	public class ContaCorrenteRepository : RepositoryBase<ContaCorrente>, IContaCorrenteRepository
	{
		public override IEnumerable<ContaCorrente> ObterTodos()
		{
			string query = "     Select * "
						 + "       From [dbo].[Contas] a "
						 + " Inner Join [dbo].[TiposDeConta] b "
						 + "         On b.ID = a.TipoDeContaID ";

			return base.conn.Query<ContaCorrente, TipoDeConta, ContaCorrente>
			(query,
				(contaCorrente, tipoDeConta) =>
				{
					contaCorrente.TipoDeConta = tipoDeConta;

					return contaCorrente;
				}
			);
		}
	}
}
