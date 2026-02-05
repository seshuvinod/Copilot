using System.Diagnostics;
using Copilot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Copilot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>? _logger;

        public HomeController(ILogger<HomeController>? logger)
        {
            logger = null;
            if(logger == null)
            {
                return;
            }
            _logger = logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Name = "VINOD M1 hhhh";
                return View();
        }

        [HttpPost]
        [Route("/post")]
        public IActionResult post([FromQuery]Emp emp, [FromBody] Emp emp1)
        {
            if ((ModelState.IsValid))
            { 
                return Ok(emp);
            }
            return View("Index");
        }
        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
