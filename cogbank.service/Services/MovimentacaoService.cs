using cogbank.gerenciador;
using cogbank.helper.Attributes;
using cogbank.helper.ExtensionMethods;
using cogbank.model;
using cogbank.model.Converter;
using cogbank.model.Interfaces.Repository;
using cogbank.model.Interfaces.Service;
using cogbank.model.ViewModels;
using System;
using System.Collections.Generic;

namespace cogbank.service.Services
{
	[InterfaceMapping("IMovimentacaoService")]
	public class MovimentacaoService : IMovimentacaoService
	{
		public MovimentacaoService(IMovimentacaoRepository repository, IContaCorrenteRepository contaCorrente)
		{
			this.repository = repository;
			this.contaCorrente = contaCorrente;
		}

		readonly IMovimentacaoRepository repository;
		readonly IContaCorrenteRepository contaCorrente;

		public MovimentacaoViewModel Adicionar(MovimentacaoViewModel dados)
		{
			try
			{
				dados.DataDaMovimentacao = DateTime.Now.DataBrasilia();

				var conta = contaCorrente.ObterPorId(dados.ContaID);

				if (dados.TipoDeMovimentacaoID == GerenciadorDeTiposDeMovimentacao.Debito)
				{
					conta.Saldo -= dados.Valor.RemoverMascaraMonetaria();
					contaCorrente.Atualizar(conta);
				}
				else if (dados.TipoDeMovimentacaoID == GerenciadorDeTiposDeMovimentacao.Credito)
				{
					conta.Saldo += dados.Valor.RemoverMascaraMonetaria();
					contaCorrente.Atualizar(conta);
				}

				this.repository.Adicionar(dados.ToMovimentacao());
			}
			catch (Exception ex)
			{
				dados.ValidationResult.Add(false, ex.Message);
			}

			return dados;
		}

		public MovimentacaoViewModel Atualizar(MovimentacaoViewModel dados)
		{
			try
			{
				this.repository.Atualizar(dados.ToModel<Movimentacao>());
			}
			catch (Exception ex)
			{
				dados.ValidationResult.Add(false, ex.Message);
			}

			return dados;
		}

		public MovimentacaoViewModel Excluir(MovimentacaoViewModel dados)
		{
			try
			{
				this.repository.Excluir(dados.ToModel<Movimentacao>());
			}
			catch (Exception ex)
			{
				dados.ValidationResult.Add(false, ex.Message);
			}

			return dados;
		}

		public MovimentacaoViewModel ObterPorId(Guid id)
			=> this.repository.ObterPorId(id).ToViewModel<MovimentacaoViewModel>();

		public IEnumerable<Movimentacao> ObterTodos()
			=> this.repository.ObterTodos();

		public IEnumerable<Movimentacao> ObterMovimentacoesDaConta(Guid id)
			=> this.repository.ObterMovimentacoesDaConta(id);
	}
}
