using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
	public class RowColKey
	{
		[Key]
		public int Row { get; set; }
		public int Col { get; set; }
		public string Key { get; set; }

	}
}