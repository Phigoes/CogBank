using cogbank.helper.ExtensionMethods;
using cogbank.model.ViewModels;

namespace cogbank.model.Converter
{
	public static class ContaCorrenteConverter
	{
		public static ContaCorrenteViewModel ToContaCorrenteViewModel(this ContaCorrente item)
		{
			return item == null
				? null
				: new ContaCorrenteViewModel
				{
					ID = item.ID,
					TipoDeContaID = item.TipoDeContaID,
					Numero = item.Numero,
					NomeDoTitular = item.NomeDoTitular,
					Saldo = item.Saldo.ToString()
				};
		}

		public static ContaCorrente ToContaCorrente(this ContaCorrenteViewModel item)
		{
			return item == null
				? null
				: new ContaCorrente(item.ID, item.Numero, item.NomeDoTitular, item.Saldo.RemoverMascaraMonetaria(), item.TipoDeContaID);
		}
	}
}
