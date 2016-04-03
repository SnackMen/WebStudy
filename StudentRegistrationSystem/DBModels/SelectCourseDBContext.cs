using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DBModels
{
	public class SelectCourseDBContext:DbContext
	{
		public SelectCourseDBContext():base("Registration")
		{

		}
		public DbSet<SelectCourse> SelectCourses { get; set; }
	}
}