using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	public class InsertStusentGrade
	{
		[Key]
		public string SNO { get; set; }
		public string SNAME { get; set; }
		public string CNAME { get; set;}
		public string GRADE { get; set; }
	}
}