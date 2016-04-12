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
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname).ToList();
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
		public ActionResult StudentList1(string tname)
		{
			int i = 0;
			SelectedCourseDBContext selectSno = new SelectedCourseDBContext();
			BasicInfoDBContext studentMessage = new BasicInfoDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			List<SelectedCourse> studentSno = selectSno.SelectedCourses.Where(u => u.TNAME == tname).ToList();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname).ToList();
			string[] className = new string[10];
			List<BasicInfo> result = new List<BasicInfo>();
			foreach (var n in cname)
			{
				className[i] = n.CNAME;
				i++;
			}
			foreach (var u in studentSno)
			{
				string name = className[0];
				if (name == u.CNAME)
				{
					List<BasicInfo> message = studentMessage.Basics.Where(m => m.ID == u.SNO && u.CNAME == name && u.SEMESTER == "15-16春").ToList();
					result.AddRange(message);
				}
			}
			return View(result);
		}
		public ActionResult StudentList2(string tname)
		{
			int i = 0;
			SelectedCourseDBContext selectSno = new SelectedCourseDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			BasicInfoDBContext studentMessage = new BasicInfoDBContext();
			List<SelectedCourse> studentSno = selectSno.SelectedCourses.Where(u => u.TNAME == tname).ToList();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname).ToList();
			string[] className = new string[cname.Count];
			List<BasicInfo> result = new List<BasicInfo>();
			foreach (var n in cname)
			{
				className[i] = n.CNAME;
				i++;
			}
			foreach (var u in studentSno)
			{
				string name = className[1];
				if (name == u.CNAME)
				{
					List<BasicInfo> message = studentMessage.Basics.Where(m => m.ID == u.SNO && u.CNAME == name && u.SEMESTER == "15-16春").ToList();
					result.AddRange(message);
				}
				
			}
			return View(result);
		}
	
		public ActionResult CourseSchedule(string tname)
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
		public ActionResult StudentGrade1(string tname)
		{
			int i = 0;
			SelectedCourseDBContext selectSno = new SelectedCourseDBContext();
			BasicInfoDBContext studentMessage = new BasicInfoDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			List<SelectedCourse> studentSno = selectSno.SelectedCourses.Where(u => u.TNAME == "王晓名").ToList();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == "王晓名").ToList();
			string[] className = new string[10];
			List<BasicInfo> result = new List<BasicInfo>();
			foreach (var n in cname)
			{
				className[i] = n.CNAME;
				i++;
			}
			foreach (var u in studentSno)
			{
				string name = className[0];
				if (name == u.CNAME)
				{
					List<BasicInfo> message = studentMessage.Basics.Where(m => m.ID == u.SNO && u.CNAME == name && u.SEMESTER == "15-16春").ToList();
					result.AddRange(message);
				}
			}
			return View(result);
		}
		public ActionResult StudentGrade2(string tname)
		{
			int i = 0;
			SelectedCourseDBContext selectSno = new SelectedCourseDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			BasicInfoDBContext studentMessage = new BasicInfoDBContext();
			List<SelectedCourse> studentSno = selectSno.SelectedCourses.Where(u => u.TNAME == "王晓名").ToList();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == "王晓名").ToList();
			string[] className = new string[cname.Count];
			List<BasicInfo> result = new List<BasicInfo>();
			foreach (var n in cname)
			{
				className[i] = n.CNAME;
				i++;
			}
			foreach (var u in studentSno)
			{
				string name = className[1];
				if (name == u.CNAME)
				{
					List<BasicInfo> message = studentMessage.Basics.Where(m => m.ID == u.SNO && u.CNAME == name && u.SEMESTER == "15-16春").ToList();
					result.AddRange(message);
				}

			}
			return View(result);
		} 
	}
}