﻿using System.Web.Mvc;

namespace cogbank.web
{
	public class RazorViewEngineCustom : RazorViewEngine
	{
		public RazorViewEngineCustom()
		{
			base.AreaViewLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}.cshtml", "~/Areas/{2}/Views/Shared/{0}.cshtml" };
			base.AreaMasterLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}.cshtml", "~/Areas/{2}/Views/Shared/{0}.cshtml" };
			base.AreaPartialViewLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}.cshtml", "~/Areas/{2}/Views/Shared/{0}.cshtml" };
			base.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.cshtml", "~/Views/Shared/{0}.cshtml" };
			base.MasterLocationFormats = new string[] { "~/Views/{1}/{0}.cshtml", "~/Views/Shared/{0}.cshtml" };
			base.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.cshtml", "~/Views/Shared/{0}.cshtml" };
			base.FileExtensions = new string[] { "cshtml" };
		}
	}
}