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
			SelectedCourseDBContext selectedcourse = new SelectedCourseDBContext();
			List<SelectedCourse> selectedResult = selectedcourse.SelectedCourses.Where(u => u.SNO.Replace(" ", "") == "S1" && u.SEMESTER.Replace(" ", "") != null).ToList();
			
			return View(selectedResult);
		}
		
		public ActionResult GradesIndex()
		{
			SelectCourseDBContext dbselectcourse = new SelectCourseDBContext();
			GradeDBContext dbgrade = new GradeDBContext();
			List<SelectCourse> lsitSelectCourse = dbselectcourse.SelectCourses.ToList();
			var listgrade = dbgrade.Grades.ToList();
			var result = (from tableGrade in dbgrade.Grades
						  join tableCourse in dbselectcourse.SelectCourses on tableGrade.CNO equals tableCourse.CNO
						  where tableGrade.SNO == "S2"
						  select new GradeAndCourse
						  {
							  CNO = tableGrade.CNO,
							  CNAME = tableCourse.CNAME,
							  CREDIT = tableCourse.CREDIT,
							  GRADE = tableGrade.GRADE
						  }).ToList();
			//var result = from tableGrade in listgrade where tableGrade.SNO == "S1" select tableGrade.GRADE;
			return View(result);
		}
		public string StudentSelectCourse(string sno,string sname,string cno,string cname)
		{
			string result = null;
			//SelectCourseDBContext selectDbContext = new SelectCourseDBContext();
			//var message = selectDbContext.SelectCourses.Where(u => u.CNO == cno &&u.CNAME==cname).FirstOrDefault();
			//SelectedCourseDBContext selectedDbContext = new SelectedCourseDBContext();
			//var isSelected = selectedDbContext.SelectedCourses.Where(u => u.CNO == cno && u.SNO == sno).FirstOrDefault();
			//if (message == null)
			//{
			//	result = "该课程不存在，请核实该课程信息!";
			//}
			//else if (message.SELECTEDNUM == message.CAPACITY)
			//{
			//	result = "该课程所选人数已达人数上限!";
			//}
			//else if (isSelected != null)
			//{
			//	result = "您已经选过该课程!";
			//}
			//else
			//{
			//	SelectedCourse selectedCourse = new SelectedCourse() { SNO = "S1", CNO = cno, CNAME = cname, CREDIT = Convert.ToInt32(credit), CDEPT = cdept, TNAME = tname, TIME = time, SEMESTER = "15-16春" };
			//	selectedDbContext.SelectedCourses.Add(selectedCourse);
			//	selectedDbContext.SaveChanges();
			//}
			result = sno + sname + cname + cno;
			return result;
		}
	}
}