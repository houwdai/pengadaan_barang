using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ManKeuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
