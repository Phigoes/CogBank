using cogbank.helper.Attributes;
using cogbank.model;
using cogbank.model.Converter;
using cogbank.model.Interfaces.Repository;
using cogbank.model.Interfaces.Service;
using cogbank.model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cogbank.service.Services
{
	[InterfaceMapping("IContaCorrenteService")]
	public class ContaCorrenteService : IContaCorrenteService
	{
		public ContaCorrenteService(IContaCorrenteRepository repository, ITipoDeContaRepository tipoDeConta)
		{
			this.repository = repository;
			this.tipoDeConta = tipoDeConta;
		}

		readonly IContaCorrenteRepository repository;
		readonly ITipoDeContaRepository tipoDeConta;

		public ContaCorrenteViewModel Adicionar(ContaCorrenteViewModel dados)
		{
			try
			{
				this.repository.Adicionar(dados.ToContaCorrente());
			}
			catch (SqlException ex)
			{
				if (ex.Number == 2627)
				{
					dados.ValidationResult.Add(false, "O Número da conta já existe!");
				}
				else
				{
					dados.ValidationResult.Add(false, ex.Message);
				}
			}

			return dados;
		}

		public ContaCorrenteViewModel Atualizar(ContaCorrenteViewModel dados)
		{
			try
			{
				dados.ID = Guid.NewGuid();

				this.repository.Atualizar(dados.ToModel<ContaCorrente>());
			}
			catch (Exception ex)
			{
				dados.ValidationResult.Add(false, ex.Message);
			}

			return dados;
		}

		public ContaCorrenteViewModel Excluir(ContaCorrenteViewModel dados)
		{
			try
			{
				this.repository.Excluir(dados.ToModel<ContaCorrente>());
			}
			catch (Exception ex)
			{
				dados.ValidationResult.Add(false, ex.Message);
			}

			return dados;
		}

		public ContaCorrenteViewModel ObterPorId(Guid id)
			=> this.repository.ObterPorId(id).ToViewModel<ContaCorrenteViewModel>();

		public IEnumerable<ContaCorrente> ObterTodos()
			=> this.repository.ObterTodos();
	}
}
