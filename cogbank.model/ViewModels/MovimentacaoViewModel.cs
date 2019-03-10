using System;
using System.ComponentModel.DataAnnotations;

namespace cogbank.model.ViewModels
{
	public class MovimentacaoViewModel : BaseViewModel
	{
		public MovimentacaoViewModel() { }

		public MovimentacaoViewModel(Guid contaID)
		{
			ID = Guid.NewGuid();
			ContaID = contaID;
		}

		[Required(ErrorMessage = "O campo tipo da movimentação é obrigatório")]
		[Display(Name = "Tipo da Movimentação")]
		public Guid TipoDeMovimentacaoID { get; set; }

		[Required(ErrorMessage = "O campo valor é obrigatório")]
		public string Valor { get; set; }

		public DateTime DataDaMovimentacao { get; set; }

		public Guid ContaID { get; set; }
	}
}
