using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
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

		public ActionResult TeachQueryTable(string tname)
		{
			int i = 0;
			GradeDBContext grade = new GradeDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == "王晓名").ToList();
			foreach (var u in cname)
			{
				@TempData[i.ToString()] = u.CNAME;
				i++;
			}
			@ViewBag.count = i;

			return View();
		}
		public ActionResult QueryTable(string tname)
		{
			SelectCourseDBContext selectCourse = new SelectCourseDBContext();
			List<SelectCourse> result = selectCourse.SelectCourses.Where(u => u.TNAME == tname).ToList();
			return View(result);
		}
		public ActionResult StudentList1()
		{
			return View();
		}
		public ActionResult StudentList2()
		{
			return View();
		}
	}
}