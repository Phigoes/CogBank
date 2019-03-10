using System;
using System.ComponentModel.DataAnnotations;

namespace cogbank.model.ViewModels
{
	public class ContaCorrenteViewModel : BaseViewModel
	{
		public ContaCorrenteViewModel()
		{
			ID = Guid.NewGuid();
		}

		[Required(ErrorMessage = "O campo tipo de conta é obrigatório")]
		[Display(Name = "Tipo de Conta")]
		public Guid TipoDeContaID { get; set; }

		[Required(ErrorMessage = "O campo número da conta é obrigatório")]
		[Display(Name = "Número da Conta")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "O campo nome do titular é obrigatório")]
		[Display(Name = "Nome do Titular")]
		public string NomeDoTitular { get; set; }

		public string Saldo { get; set; }

		public TipoDeConta TipoDeConta { get; set; }
	}
}
