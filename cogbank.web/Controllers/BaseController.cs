using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace cogbank.web.Controllers
{
	public class BaseController : Controller
	{
		public bool IsValidOperation(List<string> lista)
		{
			return (!lista.PossuiValor());
		}

		public void RegisterNotificationInModelState(List<string> lista)
		{
			foreach (var item in lista)
			{
				ModelState.AddModelError("", item);
			}
		}

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
		}
	}
}