using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace StudentRegistrationSystem.DBModels
{
	public class BasicInfoDBContext:DbContext
	{
		public BasicInfoDBContext():base("Registration")
		{

		}
		public DbSet<BasicInfo> Basics { get; set; }
	}
	
}