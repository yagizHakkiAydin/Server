using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Edit()
        {
            return View("Index");
        }
    }
}
