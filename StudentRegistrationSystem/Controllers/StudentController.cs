using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
		private List<SelectCourse> result = new List<SelectCourse> { };
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
		public ActionResult TableIndex(FormCollection fc)
		{
			string cno = fc["cno"].Replace(" ", "");
			string name = fc["cname"].Replace(" ", "");
			SelectCourseDBContext selectCourse = new SelectCourseDBContext();
			//var result = selectCourse.SelectCourses.ToList();
			if (!string.IsNullOrEmpty(cno) && !string.IsNullOrEmpty(name))
			{
				result = selectCourse.SelectCourses.Where(u => u.CNO == cno && u.CNAME==name).ToList();

			}
			return View(result);
		}

		[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
		public ActionResult SelectCourseIndex()
		{
			return View();
		}
		public ActionResult DropCourseIndex()
		{
			return View();
		}
		public ActionResult QueryTimeTableIndex()
		{
			return View();
		}
		public ActionResult GradesIndex()
		{
			return View();
		}
		
	}
}