using System;
using System.Collections.Generic;

namespace cogbank.model.Interfaces.Repository
{
	public interface IMovimentacaoRepository : IRepositoryBase<Movimentacao>
	{
		IEnumerable<Movimentacao> ObterMovimentacoesDaConta(Guid id);
	}
}
