using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels.HelloWorld;

namespace WebApplication1.Controllers
{
	public class HelloWorldController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Welcome(string name, int numTimes = 1)
		{
			var model = new WelcomeViewModel()
			{
				Name = name,
				Number = numTimes
			};

			return View(model);
		}
	}
}
