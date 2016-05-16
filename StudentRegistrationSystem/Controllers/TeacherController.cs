using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
			string tname = TempData["name"].ToString();
			int i = 0;
			GradeDBContext grade = new GradeDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname).ToList();
			foreach (var u in cname)
			{
				Session[i.ToString()] = u.CNAME;
				i++;
			}
			
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
			string number = null;
			string[,] timeTable = new string[13, 5];
			for (int i = 0; i < 13; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					timeTable[i, j] = "0";
				}
			}
			SelectCourseDBContext selectCourse = new SelectCourseDBContext();
			List<SelectCourse> result = selectCourse.SelectCourses.Where(u => u.TNAME == tname).ToList();
			Regex regexCharacter = new Regex("[\u4E00-\u9FA5]");
			Regex regexDigit = new Regex(@"(\d{1,2})-(\d{1,2})");
			foreach (var u in result)
			{
				int n = 0;
				MatchCollection characterRegex = regexCharacter.Matches(u.TIME);
				MatchCollection digitRegex = regexDigit.Matches(u.TIME);
				foreach (Match week in characterRegex)
				{
					int m = 0;
					switch (week.Value.ToString())
					{
						case "一":
							number = "0";
							break;
						case "二":
							number = "1";
							break;
						case "三":
							number = "2";
							break;
						case "四":
							number = "3";
							break;
						case "五":
							number = "4";
							break;
					}
					foreach (Match classTime in digitRegex)
					{
						if (m == n)
						{
							string[] firstTime = classTime.Value.ToString().Split('-');
							for (int i = Convert.ToInt32(firstTime[0]) - 1; i <= Convert.ToInt32(firstTime[1]) - 1; i++)
							{
								timeTable[i, Convert.ToInt32(number)] = u.CNAME;
							}
						}
						m++;
					}
					n++;
				}
			}
			RowColKey rowColKey = null;
			List<RowColKey> listRowColKey = new List<RowColKey>();
			for (int i = 0; i < 13; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (timeTable[i, j] != "0")
					{
						rowColKey = new RowColKey() { Row = i, Col = j, Key = timeTable[i, j] };
						listRowColKey.Add(rowColKey);
					}
				}
			}
			return View(listRowColKey);
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
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname).ToList();
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
			List<BasicInfo> studentName = new List<BasicInfo>();
			StudentGrade result=null;
			List<StudentGrade> resultGrade = new List<StudentGrade>();
			GradeDBContext grade = new GradeDBContext();
			List<SelectedCourse> studentSno = selectSno.SelectedCourses.Where(u => u.TNAME == tname.Replace(" ","")).ToList();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname.Replace(" ", "")).ToList();
			string[] className = new string[10];
			foreach (var n in cname)
			{
				className[i] = n.CNAME.ToString().Replace(" ","");
				i++;
			}
			foreach (var u in studentSno)
			{
				string name = className[0];
				if (name == u.CNAME.Replace(" ","") && u.SEMESTER == "15-16春")
				{
					var  message = studentMessage.Basics.Where(m => m.ID == u.SNO).FirstOrDefault();
					var gradeStudent = grade.Grades.Where(n => n.SNO == u.SNO && n.CNO == u.CNO && n.SEMESTER == "15-16春").FirstOrDefault();
					if (gradeStudent != null)
					{
						result = new StudentGrade() { SNO = message.ID, SNAME = message.NAME, GRADE = gradeStudent.GRADE };
					}
					else
					{
						result = new StudentGrade() { SNO = message.ID, SNAME = message.NAME, GRADE = null };
					}
					resultGrade.Add(result);
				}
			}
			return View(resultGrade);
		}
		public ActionResult StudentGrade2(string tname)
		{
			int i = 0;
			SelectedCourseDBContext selectSno = new SelectedCourseDBContext();
			BasicInfoDBContext studentMessage = new BasicInfoDBContext();
			SelectCourseDBContext selectCname = new SelectCourseDBContext();
			List<BasicInfo> studentName = new List<BasicInfo>();
			StudentGrade result = null;
			List<StudentGrade> resultGrade = new List<StudentGrade>();
			GradeDBContext grade = new GradeDBContext();
			List<SelectedCourse> studentSno = selectSno.SelectedCourses.Where(u => u.TNAME == tname.Replace(" ", "")).ToList();
			List<SelectCourse> cname = selectCname.SelectCourses.Where(u => u.TNAME == tname.Replace(" ", "")).ToList();
			string[] className = new string[10];
			foreach (var n in cname)
			{
				className[i] = n.CNAME.ToString().Replace(" ", "");
				i++;
			}
			foreach (var u in studentSno)
			{
				string name = className[1];
				if (name == u.CNAME.Replace(" ", "") && u.SEMESTER == "15-16春")
				{
					var message = studentMessage.Basics.Where(m => m.ID == u.SNO).FirstOrDefault();
					var gradeStudent = grade.Grades.Where(n => n.SNO == u.SNO && n.CNO == u.CNO && n.SEMESTER == "15-16春").FirstOrDefault();
					if (gradeStudent != null)
					{
						result = new StudentGrade() { SNO = message.ID, SNAME = message.NAME, GRADE = gradeStudent.GRADE };
					}
					else
					{
						result = new StudentGrade() { SNO = message.ID, SNAME = message.NAME, GRADE = null };
					}
					resultGrade.Add(result);
				}
			}
			return View(resultGrade);
		}
		public string UpdateGrade(List<InsertStusentGrade> models)
		{
			//不知道怎么将json传递过来，先放着吧，不干了，等以后再弄到再搞，现在宣布此项目暂时停住
			Grade grade = null;
			GradeDBContext gradeDbContext = new GradeDBContext();
			SelectCourseDBContext course = new SelectCourseDBContext();
			SelectCourse select = new SelectCourse();
			string result = null;
			if (models != null)
			{
				foreach (var n in models)
				{
					var cNo = course.SelectCourses.SingleOrDefault(u => u.CNAME == n.CNAME).CNO;
					string CNO = cNo.ToString();
					var newGrade = gradeDbContext.Grades.Where(u => u.SNO == n.SNO && u.CNO == CNO && u.SEMESTER == "15-16春").FirstOrDefault();
					if (newGrade == null)
					{//插入
						grade = new Grade() { SNO = n.SNO, CNO = CNO, GRADE = n.GRADE, SEMESTER = "15-16春" };
						gradeDbContext.Grades.Add(grade);
						gradeDbContext.SaveChanges();
					}
					else
					{//更新
						newGrade.GRADE = n.GRADE;
						gradeDbContext.SaveChanges();
					}
				}
			}
			else
			{
				result = "返回值为空";
			}

			result = "成功";
			return result;
		}
	}
}