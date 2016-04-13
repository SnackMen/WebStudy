﻿using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.DBModels
{
	public class ScheduleDBContext:DbContext
	{
		public ScheduleDBContext():base("Registration")
		{

		}
		public DbSet<Schedule> Schedules { get; set; }
	}
}