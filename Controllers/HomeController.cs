using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using retroom_last.Models;
using System.Linq;

namespace retroom_last.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RetrooomDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, RetrooomDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            
            var restaurants=_dbContext.Restaurants.ToList();
            var comments = _dbContext.Comments.Include(c => c.Person).Include(c => c.Restaurant).ToList();
            var mainViewModel = new MainViewModelHome(restaurants,comments);

            return View(mainViewModel);
        }

        public IActionResult FullSpecs(int ID)
        
        {
            var restaurant=_dbContext.Restaurants.Where(r=>r.ID == ID).FirstOrDefault();
            var comments=_dbContext.Comments.Include(c=>c.Person).Where(c=>c.RestaurantID==ID).ToList();

            var restaurantcommentviewmodel = new RestaurantCommentViewModel(restaurant, comments);
            return View(restaurantcommentviewmodel);
        
        }
        

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Person model)
        {
            
            try
            {
                _dbContext.People.Add(model);
                _dbContext.SaveChanges();
                var user = _dbContext.People.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);
                TempData["UID"] = user.ID;
                return RedirectToAction("Index", "AfterSign");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                var user = _dbContext.People.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);

                if (user.Password=="admin" && user.Email=="admin@admin.com") 
                {


                    TempData["UID"] = user.ID;

                    return RedirectToAction("Index", "Admin");
                }

                if (user != null)

                {
                    TempData["UID"] = user.ID;

                    return RedirectToAction("Index", "AfterSign");
                }

                ModelState.AddModelError("", "Invalid email or password");
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult search(string searchstring)
        {
            var restaurants = _dbContext.Restaurants.Where(r => r.Name.Contains(searchstring)).ToList();
            return (IActionResult)View(restaurants);
        }
    }
}
