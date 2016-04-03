using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	public class BasicInfo
	{
		[Key]
		public string ID { get; set; }
		public string NAME { get; set; }
		public string SEX { get; set; }
		public int AGE { get; set; }
		public string SDEPT { get; set; }
		public string LOGN{ get; set; }
		public string PSW{ get; set; }
	}
}