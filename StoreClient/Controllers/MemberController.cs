using Microsoft.AspNetCore.Mvc;

namespace StoreClient.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
