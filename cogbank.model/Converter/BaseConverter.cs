using cogbank.helper;
using cogbank.model.ViewModels;

namespace cogbank.model.Converter
{
	public static class BaseConverter
	{
		public static T ToViewModel<T>(this EntidadeBase item)
			=> item.Serializar().Deserializar<T>();

		public static T ToModel<T>(this BaseViewModel item)
			=> item.Serializar().Deserializar<T>();
	}
}
