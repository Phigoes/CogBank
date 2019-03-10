using cogbank.model.ViewModels;
using System;
using System.Collections.Generic;

namespace cogbank.model.Interfaces.Service
{
	public interface IMovimentacaoService
	{
		MovimentacaoViewModel Adicionar(MovimentacaoViewModel dados);
		MovimentacaoViewModel Excluir(MovimentacaoViewModel dados);
		MovimentacaoViewModel Atualizar(MovimentacaoViewModel dados);
		IEnumerable<Movimentacao> ObterTodos();
		MovimentacaoViewModel ObterPorId(Guid id);
		IEnumerable<Movimentacao> ObterMovimentacoesDaConta(Guid id);
	}
}
