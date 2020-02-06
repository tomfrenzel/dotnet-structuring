using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_structuring.library.Models
{
	public class Template
	{
		public string Name { get; set; }
		public string ShortName { get; set; }
		public override string ToString() => Name + "5";
	}
}
