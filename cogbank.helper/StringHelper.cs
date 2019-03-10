using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace cogbank.helper
{
	public class StringHelper
	{
		public static string ExtrairCaracteresNumericos(string conteudo)
			=> String.Join("", Regex.Split(conteudo, @"[^\d]"));

		public static string ExtrairCaracteresAlfabeticos(string conteudo, bool considerarAcentuacao = false, bool considerarEspacos = false)
		{
			conteudo = UnificarEspacosEmCodigoAscii32(conteudo);

			if (considerarAcentuacao)
			{
				return String.Join("", Regex.Split(conteudo, @"[^A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ" + ((considerarEspacos) ? " " : "") + "]"));
			}
			else
			{
				return String.Join("", Regex.Split(conteudo, @"[^A-Za-z" + ((considerarEspacos) ? " " : "") + "]"));
			}
		}

		public static string ExtrairCaracteresEspeciais(string conteudo)
		{
			conteudo = UnificarEspacosEmCodigoAscii32(conteudo);
			return String.Join("", Regex.Split(conteudo, @"[^0-9A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ@.,-/ ]"));
		}

		public static string ExtrairCaracteresEspeciaisFull(string conteudo)
		{
			conteudo = UnificarEspacosEmCodigoAscii32(conteudo);
			return String.Join("", Regex.Split(conteudo, @"[^0-9A-Za-z ]"));
		}

		public static string ExtrairMoeda(string conteudo)
			=> String.Join("", Regex.Split(conteudo, @"[^\d.,]"));

		public static string RemoverAcentuacao(string texto, bool RetornoEmCaixaAlta)
		{
			string s = texto.Normalize(NormalizationForm.FormD);

			StringBuilder sb = new StringBuilder();

			for (int k = 0; k < s.Length; k++)
			{
				UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
				if (uc != UnicodeCategory.NonSpacingMark)
				{
					sb.Append(s[k]);
				}
			}
			if (!RetornoEmCaixaAlta) return sb.ToString();
			else return sb.ToString().ToUpper();
		}

		public static string UnificarEspacosEmCodigoAscii32(string conteudo)
		{
			string conteudoTratado = string.Empty;

			for (int indiceDaletra = 0; indiceDaletra < conteudo.Length; indiceDaletra++)
			{
				char letra = Convert.ToChar(conteudo.Substring(indiceDaletra, 1));
				int codigoAsciiDaLetra = Convert.ToInt32(letra);

				if ((codigoAsciiDaLetra >= 0 && codigoAsciiDaLetra < 32) ||
					(codigoAsciiDaLetra == 127) ||
					(codigoAsciiDaLetra == 129) ||
					(codigoAsciiDaLetra == 141) ||
					(codigoAsciiDaLetra == 143) ||
					(codigoAsciiDaLetra == 144) ||
					(codigoAsciiDaLetra == 157) ||
					(codigoAsciiDaLetra == 160) ||
					(codigoAsciiDaLetra == 173))
				{
					conteudoTratado += Convert.ToChar(32).ToString();
				}
				else conteudoTratado += letra.ToString();
			}

			return conteudoTratado;
		}

		public static string AplicarMascaraDeCEP(string cep)
		{
			if (!string.IsNullOrEmpty(cep))
			{
				cep = cep.PadLeft(8, '0');
				return cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
			}
			else return cep;
		}

		public static string AplicarMascaraDeTelefone(string telefone)
		{
			if (!string.IsNullOrEmpty(telefone))
			{
				switch (telefone.Length)
				{
					case 8:
						return telefone.Substring(0, 4) + "-" + telefone.Substring(4, 4);
					case 9:
						return telefone.Substring(0, 5) + "-" + telefone.Substring(5, 4);
					case 10:
						return "(" + telefone.Substring(0, 2) + ")" + telefone.Substring(2, 4) + "-" + telefone.Substring(6, 4);
					case 11:
						return "(" + telefone.Substring(0, 2) + ")" + telefone.Substring(2, 5) + "-" + telefone.Substring(7, 4);
					default:
						return telefone;
				}
			}
			else return telefone;
		}
	}
}
