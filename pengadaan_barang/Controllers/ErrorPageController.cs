using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
