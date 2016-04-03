using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DBModels
{
	public class TeachingDBContext:DbContext
	{
		public TeachingDBContext():base("Registration")
		{

		}
		public DbSet<Teaching> Teaches { get; set; }
	}
}