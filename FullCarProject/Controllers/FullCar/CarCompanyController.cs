using Entity.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Repository.GenericRepository;
using Repository.IGenericRepository;

namespace FullCarProject.Controllers.FullCar
{
    public class CarCompanyController : Controller
    {
        private readonly IFullRepository<CarCompany> _carComp;
        public CarCompanyController(IFullRepository<CarCompany> car)
        {
            _carComp = car;
        }
        public async Task<IActionResult> Index(string searching)
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;

            var result = await _carComp.GetAllAsync();

            if (!string.IsNullOrEmpty(searching))
            {
                result = result.Where(x=>x.CompanyName.Contains(searching));
            }
            var viewModel = new Tuple<IEnumerable<CarCompany>, string>(result.ToList(), searching);
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCompany carCompany)
        {
            if(ModelState.IsValid)
            {
                await _carComp.Create(carCompany);
                return RedirectToAction(nameof(Index));
            }
            return View(carCompany);
        }
        public async Task<IActionResult> Yangilash(Guid id)
        {
            var car = await _carComp.GetAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> Yangilash(Guid id, CarCompany car)
        {
            if (ModelState.IsValid)
            {
                await _carComp.Update(id, car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carComp.GetAsync(id);
            if (car == null) return NotFound();
            await _carComp.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
