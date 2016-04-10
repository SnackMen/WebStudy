using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	public class GradeAndCourse
	{
		[Key]
		public string CNO { get; set; }
		public string CNAME { get; set; }
		public int CREDIT { get; set; }
		public string GRADE { get; set; }

	}
}