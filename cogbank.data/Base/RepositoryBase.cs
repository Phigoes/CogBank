using cogbank.model.Interfaces.Repository;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cogbank.data.Base
{
	public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
	{
		public RepositoryBase()
		{
			conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CogBank"].ToString());
		}

		protected readonly SqlConnection conn;

		public virtual void Adicionar(TEntity obj)
		{
			this.conn.Insert(obj);
		}

		public virtual IEnumerable<TEntity> ObterTodos()
			=> this.conn.GetAll<TEntity>();

		public virtual TEntity ObterPorId(Guid id)
			=> this.conn.Get<TEntity>(id);

		public virtual void Excluir(TEntity obj)
			=> this.conn.Delete(obj);

		public virtual void Atualizar(TEntity obj)
		{
			this.conn.Update(obj);
		}

		public void Dispose()
		{
			if (this.conn != null && this.conn.State == ConnectionState.Open)
			{
				this.conn.Close();
				this.Dispose();
			}
			GC.SuppressFinalize(this);
		}
	}
}
