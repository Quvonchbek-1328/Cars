using Entity.Models.LoginModels;
using FullCarProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Repository.IGenericRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace FullCarProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFullRepository<Login> _login;
        public HomeController(ILogger<HomeController> logger, IFullRepository<Login> login)
        {
            _logger = logger;
            _login = login;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CheckLogin(string login, string password)
        {
            var result = await _login.GetAllAsync();
            int roleId = 0;
            foreach (var loginResult in result)
            {
                if (loginResult.username.ToLower() == login.ToLower() && loginResult.password.ToLower() == password.ToLower())
                {
                    roleId = loginResult.roleId;
                    break;
                }
            }
            ViewBag.RoleId = roleId;

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login)
            };

            if (roleId == 1)
            {
                claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
            }
            else if (roleId == 2)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else if (roleId == 3)
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            if (roleId == 1)
            {
                return RedirectToAction("ThirdPage", "Admin");
            }
            else if (roleId == 2)
            {
                return RedirectToAction("SecondPage", "Admin");
            }
            else if (roleId == 3)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index"); 
        }
        public IActionResult Registratsiya()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Login login)
        {
            if(ModelState.IsValid)
            {
                await _login.Create(login);
                return RedirectToAction("Index");
            }
            return View(login);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
