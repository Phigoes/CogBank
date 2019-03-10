using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;

namespace cogbank.ioc
{
	public class SimpleInjectorBootStrapper
	{
		public static void RegisterServices(Container container, Lifestyle lifestyle)
		{
			var classesParaInjecaoDeDependencia = from a in AppDomain.CurrentDomain.GetAssemblies()
												  from t in a.GetTypes()
												  let attributes = t.GetCustomAttributes(typeof(helper.Attributes.InterfaceMapping), true)
												  where attributes != null && attributes.Length > 0
												  select new { Type = t, Attributes = attributes.Cast<helper.Attributes.InterfaceMapping>() };

			foreach (var @classe in classesParaInjecaoDeDependencia)
			{
				Assembly aplicacao = Assembly.Load("cogbank.model");
				var typeInterface = aplicacao.GetTypes().Where(c => c.IsInterface && c.Name == @classe.Attributes.FirstOrDefault().ClassName).FirstOrDefault();

				if (typeInterface.PossuiValor())
					container.Register(typeInterface, @classe.Type, lifestyle);
			}
		}
	}
}
