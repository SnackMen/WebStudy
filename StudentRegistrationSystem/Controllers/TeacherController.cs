using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
		[HttpGet]
		public ActionResult Index()
        {
			@ViewBag.tno = TempData["tno"];
			@ViewBag.tname = TempData["name"];
            return View();
        }
	}
}