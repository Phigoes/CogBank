using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cogbank.helper.ExtensionMethods
{
	public static class SystemExtends
	{
		public static DateTime DATIME_NAO_SELECIONADO = new DateTime(0);

		public static DateTime DataBrasilia(this DateTime dateTime)
			=> TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

		public static DateTime DefinirHoraComoInicioDoDia(this DateTime data)
			   => new DateTime(data.Year, data.Month, data.Day, 0, 0, 0);

		public static DateTime DefinirHoraComoFimDoDia(this DateTime data)
			   => new DateTime(data.Year, data.Month, data.Day, 23, 59, 59);

		public static bool UltimoCaracterEhUmaBarra(this string caracter)
			=> caracter.Substring(caracter.Length - 1, 1) == @"/" || caracter.Substring(caracter.Length - 1, 1) == @"\";

		public static string AddBarra(this string texto)
			=> !texto.UltimoCaracterEhUmaBarra() ? texto + @"/" : texto;

		public static string AdicionaBarraInvertida(this string texto)
			=> !texto.UltimoCaracterEhUmaBarra() ? texto + @"\" : texto;

		public static object ObterValorDaPropriedade(this object @object, string propriedade)
		{
			string[] nomesDasPropriedades = propriedade.Split('.');
			if (nomesDasPropriedades.Length == 1)
				return @object.GetType().GetProperty(propriedade).GetValue(@object, null);

			foreach (string nome in nomesDasPropriedades)
			{
				if (@object == null)
					return null;

				Type type = @object.GetType();
				PropertyInfo info = type.GetProperty(nome);
				if (info == null)
					return null;

				@object = info.GetValue(@object, null);
			}
			return @object;
		}

		public static string RemoverAcentuacao(this string texto, bool RetornoEmCaixaAlta)
		{
			if (string.IsNullOrEmpty(texto))
				return texto;

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

		public static string ExtrairCaracteresNumericos(this string conteudo)
		   => String.Join("", Regex.Split(conteudo, @"[^\d]"));

		public static decimal RemoverMascaraMonetaria(this string valorMonetario)
		{
			decimal valor = 0;

			if (!valorMonetario.PossuiValor())
				return valor;

			valorMonetario = valorMonetario.Replace("R$", "");

			decimal.TryParse(valorMonetario, out valor);

			return valor;
		}

		public static string AplicarMascaraDeDocumento(this long conteudo, string tipoDeDocumento, bool mascarar)
		{
			if (!conteudo.PossuiValor())
				return string.Empty;

			if (tipoDeDocumento == "CPF")
				return DocumentoHelper.AplicarMascaraDeCPF(conteudo.ToString().PadLeft(11, '0'), mascarar);
			else
				return DocumentoHelper.AplicarMascaraDeCNPJ(conteudo.ToString().PadLeft(14, '0'), mascarar);
		}

		public static string AplicarMascaraDeDocumento(this string conteudo, string tipoDeDocumento, bool mascarar)
		{
			if (!conteudo.PossuiValor())
				return string.Empty;

			return Convert.ToInt64(conteudo).AplicarMascaraDeDocumento(tipoDeDocumento, mascarar);
		}

		public static string AplicarMascaraDeTelefone(this string telefone)
		{
			if (!telefone.PossuiValor())
				return string.Empty;

			return StringHelper.AplicarMascaraDeTelefone(telefone);
		}

		public static string AplicarMascaraDeCEP(this string cep)
		{
			if (!cep.PossuiValor())
				return string.Empty;

			return StringHelper.AplicarMascaraDeCEP(cep);
		}

		public static string FormatarDocumento(this string valor, string tipoDeDocumento)
		{
			if (!valor.PossuiValor())
				return valor;

			if (tipoDeDocumento == "CPF")
				return valor.PadLeft(11, '0');
			else
				return valor.PadLeft(14, '0');
		}

		public static string NormalizarGuid(this Guid valor)
			=> valor.ToString().Replace('-', '_');
	}
}
