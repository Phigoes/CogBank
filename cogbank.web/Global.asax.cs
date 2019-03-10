using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace cogbank.web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			this.RetirarBuscaDeAsPXehASCXEhMelhorarSistemaDeCache();
		}

		void RetirarBuscaDeAsPXehASCXEhMelhorarSistemaDeCache()
		{
			ViewEngines.Engines.Clear();
			var ve = new RazorViewEngineCustom();
			ve.ViewLocationCache = new PerformanceCacheViewsRazor(ve.ViewLocationCache);
			ViewEngines.Engines.Add(ve);
		}
	}
}
