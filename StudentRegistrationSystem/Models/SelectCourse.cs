﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	
	public class SelectCourse
	{
		[Key]
		public int ID { get; set; }
		public string CNO { get; set; }
		public string TNO { get; set; }
		public string CNAME { get; set; }
		public int CREDIT { get; set; }
		public string CDEPT { get; set; }
		public string TNAME { get; set; }
		public int SELECTEDNUM { get; set; }
		public int CAPACITY { get; set; }
		public string TIME { get; set; }
	}
}