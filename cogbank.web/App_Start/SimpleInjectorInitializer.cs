using cogbank.ioc;
using cogbank.service.locator;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web.Mvc;

namespace cogbank.web.App_Start
{
	public class SimpleInjectorInitializer
	{
		public static void Initialize(Container container)
		{
			container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(
				defaultLifestyle: new WebRequestLifestyle(),
				fallbackLifestyle: new AsyncScopedLifestyle());

			InitializeContainer(container);
			container.Register<Hangfire.JobActivator, ContainerJobActivator>(Lifestyle.Scoped);

			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			ServiceLocator.ContainerAccessor = () => container;
		}

		private static void InitializeContainer(Container container)
		{
			SimpleInjectorBootStrapper.RegisterServices(container, Lifestyle.Scoped);
		}
	}
}