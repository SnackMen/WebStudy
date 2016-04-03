using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DBModels
{
	public class SelectedCourseDBContext:DbContext
	{
		public SelectedCourseDBContext():base("Registration")
		{

		}
		public DbSet<SelectedCourse> SelectedCourses { get; set; }
	}
}