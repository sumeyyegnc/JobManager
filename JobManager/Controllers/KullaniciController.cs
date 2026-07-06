using Microsoft.AspNetCore.Mvc;

namespace JobManager.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
