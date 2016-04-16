using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Data.Entity;
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
		
		public ActionResult GradesIndex(string sno)
		{
			SelectCourseDBContext dbselectcourse = new SelectCourseDBContext();
			GradeDBContext dbgrade = new GradeDBContext();
			SearchResult searchResult = null;
			var dbClassNo = dbgrade.Grades.Where(u => u.SNO == "S1").ToList();
			List<SearchResult> result = new List<SearchResult>();
			foreach (var u in dbClassNo)
			{
				var classMessage = dbselectcourse.SelectCourses.Where(n => n.CNO == u.CNO).FirstOrDefault();
				if (Convert.ToInt32(u.GRADE) >= 90 && Convert.ToInt32(u.GRADE)<=100)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 4.0 };
				}
				else if (Convert.ToInt32(u.GRADE)<60)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 0.0 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 85 && Convert.ToInt32(u.GRADE) <= 89)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 3.7 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 82 && Convert.ToInt32(u.GRADE) <= 84)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 3.3 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 78 && Convert.ToInt32(u.GRADE) <= 81)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 3.0 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 75 && Convert.ToInt32(u.GRADE) <= 77)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 2.7 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 72 && Convert.ToInt32(u.GRADE) <= 74)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 2.3 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 68 && Convert.ToInt32(u.GRADE) <= 71)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 2.0 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 64 && Convert.ToInt32(u.GRADE) <= 67)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 1.5 };
				}
				else if (Convert.ToInt32(u.GRADE) >= 60 && Convert.ToInt32(u.GRADE) <= 63)
				{
					searchResult = new SearchResult() { CNO = u.CNO, CNAME = classMessage.CNAME, CREDIT = classMessage.CREDIT, GRADE = u.GRADE, GPA = 1.0 };
				}
				result.Add(searchResult);
			}
			//List<SelectCourse> lsitSelectCourse = dbselectcourse.SelectCourses.ToList();
			//var listgrade = dbgrade.Grades.ToList();
			//var result = (from tableGrade in dbgrade.Grades
			//			  join tableCourse in dbselectcourse.SelectCourses on tableGrade.CNO equals tableCourse.CNO
			//			  where tableGrade.SNO == "S2"
			//			  select new GradeAndCourse
			//			  {
			//				  CNO = tableGrade.CNO,
			//				  CNAME = tableCourse.CNAME,
			//				  CREDIT = tableCourse.CREDIT,
			//				  GRADE = tableGrade.GRADE
			//			  }).ToList();
			//var result = from tableGrade in listgrade where tableGrade.SNO == "S1" select tableGrade.GRADE;
			return View(result);
		}
		public string StudentSelectCourse(string sno,string cno,string cname,string tname,string cdept,string credit,string time)
		{
			string result = null;
			SelectCourseDBContext selectDbContext = new SelectCourseDBContext();
			var message = selectDbContext.SelectCourses.Where(u => u.CNO == cno && u.CNAME == cname).FirstOrDefault();
			SelectedCourseDBContext selectedDbContext = new SelectedCourseDBContext();
			var isSelected = selectedDbContext.SelectedCourses.Where(u => u.CNO == cno && u.SNO == sno).FirstOrDefault();
			var classTime = selectedDbContext.SelectedCourses.Where(u=>u.SNO==sno).ToList();
			if (message == null)
			{
				result = "该课程不存在，请核实该课程信息!";
			}
			else if (message.SELECTEDNUM == message.CAPACITY)
			{
				result = "该课程所选人数已达人数上限!";
			}
			else if (isSelected != null)
			{
				result = "您已经选过该课程!";
			}
			else if (classTime != null)
			{
				if (IsConflict(classTime,time))
				{
					result = "课时冲突";
				}
				else
				{
					SelectedCourse selectedCourse = new SelectedCourse() { SNO = sno, CNO = cno, CNAME = cname, CREDIT = Convert.ToInt32(credit), CDEPT = cdept, TNAME = tname, TIME = time, SEMESTER = "15-16春"};
					selectedDbContext.SelectedCourses.Add(selectedCourse);
					selectedDbContext.SaveChanges();
					message.SELECTEDNUM++;
					selectDbContext.SaveChanges();
					result = "选课成功!";
				}
			}
			return result;
		}
		public bool IsConflict(List<SelectedCourse> classTimeMessage,string selectTime)
		{//如果课时冲突，那么返回true
			SelectedCourseDBContext selectedDbContext = new SelectedCourseDBContext();
			int i = 0;
			bool isTrue = false;
			Regex regexCharacter = new Regex("[\u4E00-\u9FA5]");
			Regex regexDigit = new Regex(@"(\d{1,2})-(\d{1,2})");
			foreach (var u in classTimeMessage)
			{
				MatchCollection characterRegex = regexCharacter.Matches(u.TIME);
				MatchCollection timeCharacterRegex = regexCharacter.Matches(selectTime);
				MatchCollection digitRegex = regexDigit.Matches(u.TIME);
				MatchCollection timeDiginRegex = regexDigit.Matches(selectTime);
				foreach (Match num in characterRegex)
				{
					int j = 0;
					if (isTrue==true)
					{
						break;
					}
					foreach (Match timenum in timeCharacterRegex)
					{
						int m = 0;
						if (isTrue==true)
						{
							break;
						}
						if (num.Value == timenum.Value)
						{
							foreach (Match digit in digitRegex)
							{
								int n = 0;
								if (isTrue==true)
								{
									break;
								}
								foreach (Match timeDig in timeDiginRegex)
								{
									if (i == m && j == n)
									{
										string[] course = digit.Value.ToString().Split('-');
										string[] timeCourse = timeDig.Value.ToString().Split('-');
										if ((Convert.ToInt32(course[1].ToString()) < Convert.ToInt32(timeCourse						[0].ToString())) || (Convert.ToInt32(course[0].ToString()) >						Convert.ToInt32(timeCourse[1].ToString())))
										{
											isTrue = false;
										}
										else
										{
											isTrue = true;
											break;
										}
									}
									++n;
								}
								++m;
							}
						}
						++j;
					}
					++i;
				}
			}
			return isTrue;
		}
		public string DropCourse(string sno,string cno)
		{
			string result = null;
			SelectCourseDBContext selectDbCourse = new SelectCourseDBContext();
			SelectedCourse selectedCourse = new SelectedCourse();
			SelectedCourseDBContext selectedDbCourse = new SelectedCourseDBContext();
			var selectedResult = selectedDbCourse.SelectedCourses.Where(u => u.SNO == sno && u.CNO == cno).FirstOrDefault();
			int id = selectedResult.ID;
			var deleteResult = selectedDbCourse.SelectedCourses.First(u => u.ID == id);
			selectedDbCourse.SelectedCourses.Remove(deleteResult);
			var selectResult = selectDbCourse.SelectCourses.Where(u => u.CNO == cno).FirstOrDefault();
			selectedDbCourse.SaveChanges();
			selectResult.SELECTEDNUM--;
			selectDbCourse.SaveChanges();
			result = "退课成功!";
			return result;
		}
	}
}