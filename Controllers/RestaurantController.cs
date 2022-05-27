using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.Restaurant;
using SwapiMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _context; // Injection
        public RestaurantController(RestaurantDbContext context) // Constructor 
        {
            _context = context;
        }

        public async Task<IActionResult> Index() {

            List<RestaurantListItem> restaurants = await _context.Restaurants
            .Include(r => r.Ratings)
            .Select(r => new RestaurantListItem()
            {
                Id = r.Id,
                Name = r.Name,
                Score = r.Score,
            }).ToListAsync();

            return View(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.errorMessage = ModelState.FirstOrDefault().Value.Errors.FirstOrDefault().ErrorMessage;
                return View(model);
            }
            Restaurant restaurant = new Restaurant()
            {
                Name = model.Name,
                Location = model.Location,
            };
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}