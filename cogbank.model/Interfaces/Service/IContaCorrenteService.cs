using cogbank.model.ViewModels;
using System;
using System.Collections.Generic;

namespace cogbank.model.Interfaces.Service
{
	public interface IContaCorrenteService
	{
		ContaCorrenteViewModel Adicionar(ContaCorrenteViewModel dados);
		ContaCorrenteViewModel Excluir(ContaCorrenteViewModel dados);
		ContaCorrenteViewModel Atualizar(ContaCorrenteViewModel dados);
		IEnumerable<ContaCorrente> ObterTodos();
		ContaCorrenteViewModel ObterPorId(Guid id);
	}
}
