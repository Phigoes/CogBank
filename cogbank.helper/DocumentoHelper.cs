using cogbank.helper.ExtensionMethods;

namespace cogbank.helper
{
	public class DocumentoHelper
	{
		const int TAMANHO_CPF = 11;

		public static bool EhCPF(string documento)
			=> documento.Length == TAMANHO_CPF;

		public static string AplicarMascaraDeCNPJ(string cnpj, bool mascarar)
		{
			string cnpjComMascara = string.Empty;

			if (mascarar)
			{
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(0, 2);
				cnpjComMascara += ".";
				cnpjComMascara += "XXX";
				cnpjComMascara += ".";
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(5, 2);
				cnpjComMascara += "X";
				cnpjComMascara += "/";
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(8, 4);
				cnpjComMascara += "-";
				cnpjComMascara += "XX";
			}
			else
			{
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(0, 2);
				cnpjComMascara += ".";
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(2, 3);
				cnpjComMascara += ".";
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(5, 3);
				cnpjComMascara += "/";
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(8, 4);
				cnpjComMascara += "-";
				cnpjComMascara += SystemExtends.ExtrairCaracteresNumericos(cnpj).PadLeft(14, '0').Substring(12, 2);
			}
			return cnpjComMascara;
		}

		public static string AplicarMascaraDeCPF(string cpf, bool mascarar)
		{
			string cpfComMascara = string.Empty;

			if (mascarar)
			{
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(0, 3);
				cpfComMascara += ".";
				cpfComMascara += "XXX";
				cpfComMascara += ".";
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(6, 3);
				cpfComMascara += "-";
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(9, 1);
				cpfComMascara += "X";
			}
			else
			{
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(0, 3);
				cpfComMascara += ".";
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(3, 3);
				cpfComMascara += ".";
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(6, 3);
				cpfComMascara += "-";
				cpfComMascara += SystemExtends.ExtrairCaracteresNumericos(cpf).PadLeft(11, '0').Substring(9, 2);
			}
			return cpfComMascara;
		}

		public static bool EhCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

		public static bool EhCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}
	}
}
