using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
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
    }
}