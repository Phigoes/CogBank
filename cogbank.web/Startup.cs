using cogbank.web.App_Start;
using Hangfire;
using Hangfire.SimpleInjector;
using Microsoft.Owin;
using Owin;
using SimpleInjector;

[assembly: OwinStartup(typeof(cogbank.web.Startup))]
namespace cogbank.web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			GlobalConfiguration.Configuration.UseSqlServerStorage("CogBank");

			var container = new Container();
			SimpleInjectorInitializer.Initialize(container);
			GlobalConfiguration.Configuration.UseActivator(new SimpleInjectorJobActivator(container));
			GlobalJobFilters.Filters.Add(new SimpleInjectorAsyncScopeFilterAttribute(container));
			GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });

			app.UseHangfireDashboard("/CogJobs");
			app.UseHangfireServer();
		}
	}
}