using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace StudentRegistrationSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
			ViewBag.no = TempData["no"];
			ViewBag.name = TempData["name"];
            return View();
        }
		[HttpPost]
		public ActionResult SetTime(FormCollection fc)
		{
			Schedule startSchedule = new Schedule();
			ScheduleDBContext startScheduledbContext = new ScheduleDBContext();
			Schedule overSchedule = new Schedule();
			ScheduleDBContext overScheduledbContext = new ScheduleDBContext();
			var start = startScheduledbContext.Schedules.Where(u => u.ID == 1).FirstOrDefault();
			var over = overScheduledbContext.Schedules.Where(u => u.ID == 2).FirstOrDefault();
			string startTime = fc["begin-time"];
			string overTime = fc["over-time"];
			if (startTime != null && overTime != null)
			{
				if (start == null)
				{
					string startyear = startTime.Substring(0, 4);
					string startmonth = startTime.Substring(5, 2);
					string startday = startTime.Substring(8, 2);
					string starthour = startTime.Substring(11, 2);
					string startminute = startTime.Substring(14, 2);

					startSchedule = new Schedule() { Year = startyear, Month = startmonth, Day = startday, Hour = starthour, Minute = startminute };
					startScheduledbContext.Schedules.Add(startSchedule);
					startScheduledbContext.SaveChanges();
				}
				else
				{
					start.Year = startTime.Substring(0, 4);
					start.Month = startTime.Substring(5, 2);
					start.Day = startTime.Substring(8, 2);
					start.Hour = startTime.Substring(11, 2);
					start.Minute = startTime.Substring(14, 2);
					startScheduledbContext.SaveChanges();
				}
				if (over == null)
				{
					string overyear = overTime.Substring(0, 4);
					string overmonth = overTime.Substring(5, 2);
					string overday = overTime.Substring(8, 2);
					string overhour = overTime.Substring(11, 2);
					string overminute = overTime.Substring(14, 2);
					overSchedule = new Schedule() { Year = overyear, Month = overmonth, Day = overday, Hour = overhour, Minute = overminute };
					overScheduledbContext.Schedules.Add(overSchedule);
					overScheduledbContext.SaveChanges();
				}
				else
				{
					over.Year = overTime.Substring(0, 4);
					over.Month = overTime.Substring(5, 2);
					over.Day = overTime.Substring(8, 2);
					over.Hour = overTime.Substring(11, 2);
					over.Minute = overTime.Substring(14, 2);
					overScheduledbContext.SaveChanges();
				}
			}
			return View("Index");
		}

		[WebMethod]
		public string Dilatation(string classNumber, string className, string classCapacity)
		{
			string message = null;
			SelectCourseDBContext selectDbCourse = new SelectCourseDBContext();
			var result = selectDbCourse.SelectCourses.Where(u => u.CNO == classNumber && u.CNAME == className).FirstOrDefault();
			if (result == null)
			{
				message = "没有查到该课程！";
			}
			else
			{
				int number = result.CAPACITY;
				result.CAPACITY = number + Convert.ToInt32(classCapacity);
				selectDbCourse.SaveChanges();
				message = "扩容成功";
				
			}
			
			return message;
		}
		public ActionResult InputFiled()
		{
			return View();
		}

		public string AddCourse(string tno,string tname,string cno,string cname,string credit,string cdept,string time,string selectednum,string capacity)
		{
			string lastResult = null;
			BasicInfoDBContext basicDbInfo = new BasicInfoDBContext();
			SelectCourse selectcourse;
			SelectCourseDBContext selectDbContext = new SelectCourseDBContext();
			var result = basicDbInfo.Basics.Where(u => u.ID == tno && u.NAME == tname).FirstOrDefault();//判断教师是否存在
			//教师是否存在
			if (result == null)
			{
				lastResult = "该教师不存在，请核实!";
			}
			//教师存在
			else
			{
				var teacherTeachCourse = selectDbContext.SelectCourses.Where(u => u.TNAME == tname).ToList();
				//该教师自己课程间是否冲突
				foreach (var t in teacherTeachCourse)
				{
					if (t.TIME.ToString().Trim() == time||t.CNO.ToString().Trim()==cno)
					{
						lastResult = "该教师课时或课号冲突，请重新确认!";
						break;
					}
				}
				if (lastResult == null)
				{
					selectcourse = new SelectCourse() { CNO = cno, TNO = tno, CNAME = cname, CREDIT = Convert.ToInt32(credit), CDEPT = cdept, TNAME = tname, TIME = time, SELECTEDNUM = Convert.ToInt32(selectednum), CAPACITY = Convert.ToInt32(capacity) };
					selectDbContext.SelectCourses.Add(selectcourse);
					selectDbContext.SaveChanges();
					lastResult = "添加成功！";
				}
			}
			return lastResult;
		}
	}
}