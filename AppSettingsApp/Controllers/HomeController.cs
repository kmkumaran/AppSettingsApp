using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSettingsApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (IsFeatureEnabled())
			{
				throw new InvalidOperationException();
			}

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			if (IsFeatureEnabled())
			{
				throw new InvalidOperationException();
			}

			return View();
		}

		public ActionResult Contact()
		{
			if (IsFeatureEnabled())
			{
				throw new InvalidOperationException();
			}

			ViewBag.Message = "Your contact page.";

			return View();
		}

		private bool IsFeatureEnabled()
		{
			bool featureEnabledStatus = true;
			const string featureStatuskey = "EnableNewFeature";

			try
			{
				var appSettings = ConfigurationManager.AppSettings;
				featureEnabledStatus = Convert.ToBoolean(appSettings[featureStatuskey]);
			}
			catch (ConfigurationErrorsException)
			{
				Console.WriteLine("Error reading app settings");
			}


			return featureEnabledStatus;
		}
	}
}