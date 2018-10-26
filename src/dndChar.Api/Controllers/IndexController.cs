using Microsoft.AspNetCore.Mvc;

namespace dndChar.Api.Controllers
{
    [Route("/")]
    public class IndexController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Character");
            }
            return View();
        }
    }
}