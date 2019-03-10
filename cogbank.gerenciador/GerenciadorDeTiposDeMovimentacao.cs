using System;

namespace cogbank.gerenciador
{
	public class GerenciadorDeTiposDeMovimentacao
	{
		public static Guid Credito
		{
			get
			{
				return Guid.Parse("09EFA2EA-00AB-4FCE-A9C8-1528BD58B8A5");
			}
		}

		public static Guid Debito
		{
			get
			{
				return Guid.Parse("C37ED6CE-B8F9-45BB-A636-C6EB291753DD");
			}
		}
	}
}
