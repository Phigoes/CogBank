using cogbank.data.Extension;
using cogbank.gerenciador;
using cogbank.model;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Linq;

namespace cogbank.data.SQLInitializer
{
	public class InicializarTiposDeMovimentacao
	{
		public static void Execute(SqlConnection conn)
		{
			if (conn.GetAll<TipoDeMovimentacao>().Where(x => x.ID == GerenciadorDeTiposDeMovimentacao.Credito).Count() <= 0)
				conn.AddOrUpdateDapper(new TipoDeMovimentacao(GerenciadorDeTiposDeMovimentacao.Credito, "Crédito"));
			if (conn.GetAll<TipoDeMovimentacao>().Where(x => x.ID == GerenciadorDeTiposDeMovimentacao.Debito).Count() <= 0)
				conn.AddOrUpdateDapper(new TipoDeMovimentacao(GerenciadorDeTiposDeMovimentacao.Debito, "Débito"));
		}
	}
}
