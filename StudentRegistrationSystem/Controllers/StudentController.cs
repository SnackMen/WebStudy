using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
using System.Web.Mvc;
using System.Linq;
namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(string cno, string name)
		{
			SelectCourseDBContext selectCourse = new SelectCourseDBContext();
			var result = selectCourse.SelectCourses.ToList();
			if (!string.IsNullOrEmpty(cno) && !string.IsNullOrEmpty(name))
			{
				result = selectCourse.SelectCourses.Where(u => u.CNO == cno && u.CNAME==name).ToList();

			}
			return PartialView("TableIndex", result);
		}
		
	}
}