using System;
using System.Collections.Generic;

namespace cogbank.model.Interfaces.Repository
{
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		void Adicionar(TEntity obj);
		TEntity ObterPorId(Guid id);
		IEnumerable<TEntity> ObterTodos();
		void Atualizar(TEntity obj);
		void Excluir(TEntity obj);
	}
}
