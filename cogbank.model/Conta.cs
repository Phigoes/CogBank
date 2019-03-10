using System;

namespace cogbank.model
{
	public class Conta : EntidadeBase
	{
		public Conta() { }

		public Conta(Guid id, int numero, string nomeDoTitular, decimal saldo)
		{
			ID = id;
			Numero = numero;
			NomeDoTitular = nomeDoTitular;
			Saldo = saldo;
		}

		public int Numero { get; set; }

		public string NomeDoTitular { get; set; }

		public decimal Saldo { get; set; }
	}
}
