using Entity.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Repository.IGenericRepository;

namespace FullCarProject.Controllers.FullCar
{
    public class CarModelController : Controller
    {
        private readonly IFullRepository<CarModel> _carComp;
        public CarModelController(IFullRepository<CarModel> car)
        {
            _carComp = car;
        }
        public async Task<IActionResult> Index(string searching)
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;

            var result = await _carComp.GetAllAsync();

            if (!string.IsNullOrEmpty(searching))
            {
                result = result.Where(x => x.Model.Contains(searching));
            }
            var viewModel = new Tuple<IEnumerable<CarModel>, string>(result.ToList(), searching);
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                await _carComp.Create(carModel);
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }
        public async Task<IActionResult> Yangilash(Guid id)
        {
            var car = await _carComp.GetAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> Yangilash(Guid id, CarModel car)
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
