using System.Configuration;
using System.Data.SqlClient;

namespace cogbank.data.SQLInitializer
{
	public static class DbInitializer
	{
		public static void Initialize()
		{
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CogBank"].ToString());

			InicializarTiposDeConta.Execute(conn);
			InicializarTiposDeMovimentacao.Execute(conn);
		}
	}
}
