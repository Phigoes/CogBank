using cogbank.helper.ExtensionMethods;
using cogbank.model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cogbank.model.Converter
{
	public static class MovimentacaoConverter
	{
		public static MovimentacaoViewModel ToMovimentacaoViewModel(this Movimentacao item)
		{
			return item == null
				? null
				: new MovimentacaoViewModel
				{
					ID = item.ID,
					TipoDeMovimentacaoID = item.TipoDeMovimentacaoID,
					Valor = item.Valor.ToString(),
					DataDaMovimentacao = item.DataDaMovimentacao,
					ContaID = item.ContaID
				};
		}

		public static Movimentacao ToMovimentacao(this MovimentacaoViewModel item)
		{
			return item == null
				? null
				: new Movimentacao(item.ID, item.TipoDeMovimentacaoID, item.Valor.RemoverMascaraMonetaria(), item.DataDaMovimentacao, item.ContaID);
		}
	}
}
