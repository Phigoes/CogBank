using cogbank.helper.ExtensionMethods;
using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;

namespace cogbank.data.Extension
{
	public static class SqlExtension
	{
		public static void AddOrUpdateDapper<TEntity>(this SqlConnection conn, TEntity obj) where TEntity : class
		{
			var entidade = conn.Get<TEntity>(obj.ObterValorDaPropriedade("ID"));

			if (entidade.PossuiValor())
				conn.Update(obj);
			else
				conn.Insert(obj);
		}
	}
}
