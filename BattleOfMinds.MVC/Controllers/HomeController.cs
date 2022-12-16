using BattleOfMinds.Models.Models;
using BattleOfMinds.MVC.Communication;
using BattleOfMinds.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BattleOfMinds.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IServiceCommunication _serviceCommuniction;
        public HomeController(ILogger<HomeController> logger, IServiceCommunication serviceCommuniction)
        {
            _logger = logger;
            _serviceCommuniction = serviceCommuniction;
        }

        public async Task<IActionResult> Index()
        {
            List<Questions> questions = new List<Questions>();
            questions = await _serviceCommuniction.GetResponseList<Questions>("api/Questions/GetAllQuestions");
            return View(questions);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        /*public string Add(){
            return "Battle of Minds";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}