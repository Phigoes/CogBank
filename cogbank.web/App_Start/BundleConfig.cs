using System.Web;
using System.Web.Optimization;

namespace cogbank.web
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-3.3.1.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/messenger").Include(
					  "~/Scripts/messenger/messenger.min.js",
					  "~/Scripts/messenger/messenger-theme-flat.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
					  "~/Content/messenger/messenger.css",
					  "~/Content/messenger/messenger-theme-flat.css"));

			bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
					  "~/Scripts/Notificacao/messenger.js",
					  "~/Scripts/Mascara/jquery.maskMoney.js"));
		}
	}
}
