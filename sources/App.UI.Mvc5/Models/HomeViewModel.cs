using App.UI.Mvc5.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace App.UI.Mvc5.Models
{
	public class HomeViewModel : BaseViewModel
	{
		[Display(Name = "Search", ResourceType = typeof(HomeAreaResources))]
		[MinLength(length: 1)]
		public string Query { get; set; }
	}
}
