using cogbank.data.Extension;
using cogbank.gerenciador;
using cogbank.model;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Linq;

namespace cogbank.data.SQLInitializer
{
	public class InicializarTiposDeConta
	{
		public static void Execute(SqlConnection conn)
		{
			if (conn.GetAll<TipoDeConta>().Where(x => x.ID == GerenciadorDeTiposDeConta.ContaCorrente).Count() <= 0)
				conn.AddOrUpdateDapper(new TipoDeConta(GerenciadorDeTiposDeConta.ContaCorrente, "Conta Corrente"));
		}
	}
}
