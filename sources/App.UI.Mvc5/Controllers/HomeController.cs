using App.UI.Mvc5.Infrastructure;
using App.UI.Mvc5.Models;
using Domain.Core.Repositories;
using Omu.ValueInjecter;
using System.Web.Mvc;

namespace App.UI.Mvc5.Controllers
{
	[RoutePrefix("")]
	[TrackMenuItem("root.landing")]
	public class HomeController : __BaseController
	{
		internal readonly IPlayerRepository playerRepository;

		public HomeController(IPlayerRepository playerRepository)
		{
			this.playerRepository = playerRepository;
		}

		[HttpGet]
		[Route(Name = "Root_Home_Index_Get")]
		public ActionResult Index()
		{
			var model = BuildHomeViewModel();
			return View(model);
		}


		private HomeViewModel BuildHomeViewModel(HomeViewModel postedModel = null)
		{
			var model = new HomeViewModel();	

			if (postedModel != null)
			{
				// Use a mapper to associate the previously posted information to the new model.
				model.InjectFrom(postedModel);
			}
			else
			{
				model.Query = "";
			}

			return model;
		}
	}
}
