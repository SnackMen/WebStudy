using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DBModels
{
	public class GradeDBContext:DbContext
	{
		public GradeDBContext() : base("Registration")
		{

		}
		public DbSet<Grade> Grades { get; set; }
	}
}