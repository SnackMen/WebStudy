using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	public class SearchResult
	{
		[Key]
		public string CNO { get; set; }
		public string CNAME { get; set; }
		public int CREDIT { get; set; }
		public string GRADE { get; set; }
		public double GPA { get; set; }

	}
}