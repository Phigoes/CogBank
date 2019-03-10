using cogbank.helper;
using System;
using System.Collections.Generic;

namespace cogbank.model
{
	public class Validate
	{
		public bool IsOK { get; set; }
		public string Message { get; set; }
	}

	public class ValidationResult
	{
		public ValidationResult()
		{
			Erros = new List<string>();
			MessageSuccess = "Operação realizada com sucesso.";
			IsOK = true;
		}

		public bool IsOK { get; set; }
		public List<string> Erros { get; set; }
		public string MessageSuccess { get; set; }

		public void Add(bool isOK, string message)
		{
			if (!isOK)
			{
				this.IsOK = isOK;
				Erros.Add(message);
			}
		}

		public void AddList(IList<Validate> listValidate)
		{
			if (listValidate == null || listValidate.Count <= 0)
				return;

			foreach (var item in listValidate)
			{
				this.Add(item.IsOK, item.Message);
			}
		}

		public void AddList(List<string> ListaDeErros)
		{
			if (ListaDeErros == null)
				throw new Exception("Lista não inicializado!!!");

			foreach (var item in ListaDeErros)
			{
				this.Add(false, item);
			}
		}

		public string ObterMensagensDeErroHtml()
		{
			var retorno = "";

			if (this.Erros.PossuiValor<string>())
			{
				foreach (var erro in this.Erros)
				{
					retorno += erro + "<br />";
				}
			}

			return retorno;
		}
	}
}
