using Entity.Models.CarModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IGenericRepository;

namespace FullCarProject.Controllers
{
    public class CarCrudController : Controller
    {
        private readonly IFullRepository<Car> _fullRepository;

        public CarCrudController(IFullRepository<Car> fullRepository)
        {
            _fullRepository = fullRepository;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.UserName = User.Identities.FirstOrDefault().Name;

            var cars = await _fullRepository.GetAllAsync(); 



            if (!string.IsNullOrEmpty(searchString))
            {
                
                cars = cars.Where(c => c.Year.ToString().Contains(searchString) ||
                                        c.Type.Contains(searchString) ||
                                        c.CompanyName.Contains(searchString) ||
                                        c.Model.Contains(searchString) ||
                                        c.Price.ToString().Contains(searchString) ||
                                        c.Condition.Contains(searchString));
            }

            var result = cars.ToList();
            var model = Tuple.Create(result.AsEnumerable(), searchString);
            return View(model); 
        }

        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid) 
            {
                await _fullRepository.Create(car);
                return RedirectToAction(nameof(Index)); 
            }
            return View(car); 
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _fullRepository.GetAsync(id);
            if (car == null) return NotFound();
            return View(car); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Car car)
        {
            if (ModelState.IsValid)
            {
                await _fullRepository.Update(id, car);
                return RedirectToAction(nameof(Index)); 
            }
            return View(car);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _fullRepository.GetAsync(id);
            if (car == null) return NotFound();
            await _fullRepository.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
