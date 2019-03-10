using System.Collections.Generic;
using System.Linq;

namespace System
{
	public static class EstadoHelper
	{
		public static bool PossuiValor(this int valor)
			=> valor > 0;

		public static bool PossuiValor(this object valor)
			=> valor != null;

		public static bool PossuiValor(this Guid valor)
			=> valor != null && valor != Guid.Empty;

		public static bool PossuiValor(this string valor)
			=> !string.IsNullOrWhiteSpace(valor);

		public static bool PossuiValor<T>(this IEnumerable<T> valor)
			=> valor != null && valor.Count() > 0;

		public static bool PossuiValor(this DateTime valor)
			=> valor != null && valor != DateTime.MinValue;
	}
}
