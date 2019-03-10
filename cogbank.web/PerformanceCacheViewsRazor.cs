using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace cogbank.web
{
	public class PerformanceCacheViewsRazor : IViewLocationCache
	{
		public PerformanceCacheViewsRazor(IViewLocationCache cache)
		{
			this.cache = cache;
		}

		readonly static object s_key = new object();
		readonly IViewLocationCache cache;

		public string GetViewLocation(HttpContextBase httpContext, string key)
		{
			var requestCache = GetRequestCache(httpContext);
			string location;
			if (!requestCache.TryGetValue(key, out location))
			{
				location = this.cache.GetViewLocation(httpContext, key);
				requestCache[key] = location;
			}
			return location;
		}

		static IDictionary<string, string> GetRequestCache(HttpContextBase httpContext)
		{
			var context = httpContext.Items[s_key] as IDictionary<string, string>;
			if (context == null)
			{
				context = new Dictionary<string, string>();
				httpContext.Items[s_key] = context;
			}
			return context;
		}

		public void InsertViewLocation(HttpContextBase httpContext, string key, string virtualPath)
			=> this.cache.InsertViewLocation(httpContext, key, virtualPath);
	}
}