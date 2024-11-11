using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullCarProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;
            return View();
        }
        [Authorize(Roles ="Admin,SuperAdmin")]
        public IActionResult SecondPage()
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult ThirdPage()
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;
            return View();
        }
    }
}
