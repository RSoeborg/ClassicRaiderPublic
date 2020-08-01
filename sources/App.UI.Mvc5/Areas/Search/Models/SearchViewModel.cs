using App.UI.Mvc5.Models;
using Domain.Core.Entities;

namespace App.UI.Mvc5.Areas.Search.Models
{
	public class SearchViewModel : BaseViewModel
	{
		public string Query { get; set; }

		public PlayerEntity[] Players { get; set; }
	}
}
