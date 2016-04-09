using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	public class Grade
	{
		[Key]
		public int ID { get; set; }
		public string SNO { get; set; }
		public string CNO { get; set; }
		public string GRADE { get; set; }
	}
}