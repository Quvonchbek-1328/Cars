using Entity.Models.CarModels;
using Entity.Models.LoginModels;
using Microsoft.AspNetCore.Mvc;
using Repository.IGenericRepository;

namespace FullCarProject.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly IFullRepository<Login> _fullRepository;
        private readonly IFullRepository<Role> _fullRepositoryRole;
        public SuperAdminController(IFullRepository<Login> fullRepository, IFullRepository<Role> fullRepository1)
        {
            _fullRepository = fullRepository;
            _fullRepositoryRole = fullRepository1;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;

            var logins = await _fullRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                logins = logins.Where(l => l.username.Contains(searchString) ||
                                           l.FirstName.Contains(searchString) ||
                                           l.LastName.Contains(searchString) ||
                                           l.email.Contains(searchString) ||
                                           l.NickName.Contains(searchString));
            }

           
            var model = new Tuple<IEnumerable<Login>, string>(logins, searchString);

            return View(model);
        }


        public async Task<IActionResult> RoleGet()
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;
            var result = await _fullRepositoryRole.GetAllAsync();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Login login)
        {
            if (ModelState.IsValid)
            {
                await _fullRepository.Create(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var login = await _fullRepository.GetAsync(id);
            if (login == null) return NotFound();
            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Login login)
        {
            if (ModelState.IsValid)
            {
                await _fullRepository.Update(id, login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var login = await _fullRepository.GetAsync(id);
            if (login == null) return NotFound();
            await _fullRepository.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
