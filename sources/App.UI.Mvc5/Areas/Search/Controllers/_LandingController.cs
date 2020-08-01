using App.UI.Mvc5.Areas.Search.Models;
using App.UI.Mvc5.Models;
using Domain.Core.Repositories;
using Omu.ValueInjecter;
using System.Linq;
using System.Web.Mvc;

namespace App.UI.Mvc5.Areas.Search.Controllers
{
	[RoutePrefix("")]
	public class _LandingController : __AreaBaseController
	{
		private IPlayerRepository PlayerRepository;

		public _LandingController(IPlayerRepository PlayerRepository)
		{
			this.PlayerRepository = PlayerRepository;
		}

		[HttpGet]
		[Route(Name = "Search_Landing_Index_Get")]
		public ActionResult Index(SearchViewModel Search)
		{
			Search = BuildSearchViewModel(Search);
			return View(Search);
		}

		private SearchViewModel BuildSearchViewModel(SearchViewModel postedModel = null)
		{
			var model = new SearchViewModel();

			if (postedModel != null)
				model.InjectFrom(postedModel);
			
			if (!string.IsNullOrWhiteSpace(model.Query))
			{
				model.Players = PlayerRepository.QueryByName(model.Query).ToArray();	
			}
			
			return model;
		}


		// GET [API]
		// search/recent-search-data
		[HttpGet]
		[Route("recent-search-data", Name = "Search_Landing_RecentSearchData_Get")]
		public ActionResult BroadcastData()
		{
			var SampleQuery = PlayerRepository.QueryByName("T").Take(10);

			return Json(new {
				data = SampleQuery.ToArray()
			});
		}
	}
}
