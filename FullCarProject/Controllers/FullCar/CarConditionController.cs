using Entity.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Repository.IGenericRepository;

namespace FullCarProject.Controllers.FullCar
{
    public class CarConditionController : Controller
    {

        private readonly IFullRepository<CarCondition> _carComp;
        public CarConditionController(IFullRepository<CarCondition> car)
        {
            _carComp = car;
        }
        public async Task<IActionResult> Index(string searching)
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;

            var result = await _carComp.GetAllAsync();

            if (!string.IsNullOrEmpty(searching))
            {
                result = result.Where(x => x.Condition.Contains(searching));
            }
            var viewModel = new Tuple<IEnumerable<CarCondition>, string>(result.ToList(), searching);
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCondition carCondition)
        {
            if (ModelState.IsValid)
            {
                await _carComp.Create(carCondition);
                return RedirectToAction(nameof(Index));
            }
            return View(carCondition);
        }
        public async Task<IActionResult> Yangilash(Guid id)
        {
            var car = await _carComp.GetAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> Yangilash(Guid id, CarCondition car)
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

