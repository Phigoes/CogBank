using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace cogbank.helper
{
	public static class JsonHelper
	{
		public static string Serializar(this object valor, bool identar = false)
		{
			var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

			if (identar)
				return JsonConvert.SerializeObject(valor, Formatting.Indented, jset);
			else
				return JsonConvert.SerializeObject(valor, jset);
		}

		public static string SerializarComUniversalDateTime(this object valor)
		{
			var isoDateTimeConverter = new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AdjustToUniversal, DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK" };
			return JsonConvert.SerializeObject(valor, isoDateTimeConverter);
		}

		public static T Deserializar<T>(this string valor)
			=> JsonConvert.DeserializeObject<T>(valor);

		public static List<T> DeserializarLista<T>(this string valor)
			=> JsonConvert.DeserializeObject<List<T>>(valor);

		public static object Deserializar(this string valor, Type tipo)
			=> JsonConvert.DeserializeObject(valor, tipo);

		public static T Deserializar<T>(this object valor)
		   => JsonConvert.DeserializeObject<T>(JsonHelper.Serializar(valor));

		public static T Clonar<T>(T valor)
		{
			string objetoSerializado = Serializar(valor);
			return Deserializar<T>(objetoSerializado);
		}
	}
}
