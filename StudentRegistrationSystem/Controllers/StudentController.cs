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

		[HttpGet]
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

		[HttpPost]
		public ActionResult Index(string sno)
		{
			SelectedCourseDBContext selectedcourse = new SelectedCourseDBContext();
			List<SelectedCourse> selectedResult = selectedcourse.SelectedCourses.Where(u => u.SNO.Replace(" ", "").Contains("S1") && u.SEMESTER.Replace(" ", "").Contains("15-16春")).Distinct().ToList();
			return PartialView("DropCourseIndex", selectedResult);
		}
		public ActionResult DropCourseIndex()
		{
			return View();
		}
		public ActionResult QueryTimeTableIndex(string sno)
		{
			//查询到了三条记录，数量正确，但是三条记录都是相同的
			SelectedCourseDBContext selectedcourse = new SelectedCourseDBContext();
			List<SelectedCourse> selectedResult = selectedcourse.SelectedCourses.Where(u => u.SNO.Replace(" ", "") == "S1" && u.SEMESTER.Replace(" ", "") != null).ToList();
			
			return View(selectedResult);
		}
		public ActionResult GradesIndex()
		{
			SelectCourseDBContext dbselectcourse = new SelectCourseDBContext();
			GradeDBContext dbgrade = new GradeDBContext();
			//GradeAndCourse gradecourse = new GradeAndCourse();
			//var result = from tableCourse in dbselectcourse.SelectCourses
			//					 join tableGrade in dbgrade.Grades on tableCourse.CNO equals tableGrade.CNO
			//					 where tableGrade.SNO == "S1"
			//					 select tableCourse.CNAME;
							   //select new GradeAndCourse
							   //{
							   //	CNO = tableGrade.CNO,
							   //	CNAME = tableCourse.CNAME,
							   //	CREDIT = tableCourse.CREDIT,
							   //	GRADE = tableGrade.GRADE
							   //};
			var result = from tableCourse in dbselectcourse.SelectCourses
											where tableCourse.CNO == "C1"
											select new
											{
												tableCourse.CNAME,
												tableCourse.CREDIT
											};
			return View(result);
		}
	}
}