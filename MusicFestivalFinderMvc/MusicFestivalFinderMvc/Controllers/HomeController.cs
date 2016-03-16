﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicFestivalFinderMvc.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			return View();
		}

		public ActionResult About() {
			ViewBag.Message = "More info about this application.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Christian Grosskopf's .NET Project";

			return View();
		}
	}
}