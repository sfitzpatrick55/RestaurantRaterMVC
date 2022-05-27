using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Data;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _context; // Injection
        public RestaurantController(RestaurantDbContext context) // Constructor 
        {
            _context = context;
        }
    }
}