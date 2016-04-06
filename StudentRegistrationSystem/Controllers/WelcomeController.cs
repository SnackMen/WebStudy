using StudentRegistrationSystem.DBModels;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/
        public ActionResult Welcome()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Welcome(FormCollection fc)
		{
			string name = fc["UserName"];
			string password = fc["Password"];
			BasicInfo basics = new BasicInfo();
			BasicInfoDBContext basic = new BasicInfoDBContext();
			//判断输入的是否为空
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
			{
				Response.Write("<script> alert('输入用户名或密码错误，请重新输入！！');window.location.href='../Welcome/Welcome' </script>");
				Response.End();
				return RedirectToAction("Welcome", "WelcomeController");
			}
			else
			{
				var userInfoCheck = from message in basic.Basics where message.LOGN == name && message.PSW == password select message.ID;
				string userInfo = null;
				foreach (var message in userInfoCheck)
				{
					userInfo = message.ToString();
				}
				if (userInfo == null)
				{
					Response.Write("<script> alert('输入用户名或密码错误，请重新输入！！');window.location.href='../Welcome/Welcome' </script>");
					Response.End();
					return RedirectToAction("Welcome", "WelcomeController");
				}
				//判断用户类型，返回不同页面
				else if (userInfo == "Admin")
				{
					basics = basic.Basics.Find(userInfo);
					TempData["name"] = basics.NAME;
					TempData["no"] = basics.LOGN;
					return Redirect("../Admin/Index");
				}
				else if (userInfo == "T1" || userInfo == "T2" || userInfo == "T3" || userInfo == "T4" || userInfo == "T5")
				{
					basics = basic.Basics.Find(userInfo);
					TempData["name"] = basics.NAME;
					TempData["tno"] = basics.LOGN;
					return RedirectToAction("Index", "Teacher");
				}
				else
				{
					basics = basic.Basics.Find(userInfo);
					TempData["name"] = basics.NAME;
					TempData["sno"] = basics.LOGN;
					return RedirectToAction("Index", "Student");
				}
			}
		}
    }
}
