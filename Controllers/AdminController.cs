using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using retroom_last.Models;

namespace retroom_last.Controllers
{
    public class AdminController : Controller
    {
        private readonly RetrooomDbContext _dbContext;

        public AdminController(RetrooomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            var comments = _dbContext.Comments.Include(c => c.Person).Include(c => c.Restaurant).ToList();
            var restaurants = _dbContext.Restaurants.ToList();
            var mainViewModel = new MainViewModelHome(restaurants, comments);
            return View(mainViewModel);
        }
        public IActionResult AdminFullSpecs(int ID)

        {
            var restaurant = _dbContext.Restaurants.Where(r => r.ID == ID).FirstOrDefault();
            var comments = _dbContext.Comments.Include(c => c.Person).Where(c => c.RestaurantID == ID).ToList();

            var restaurantcommentviewmodel = new RestaurantCommentViewModel(restaurant, comments);
            return View(restaurantcommentviewmodel);

        }

        public IActionResult RestaurantDelete(int ID) 
        { 
            
            var Restaurant = _dbContext.Restaurants.Where(r => r.ID == ID).First();
            _dbContext.Restaurants.Remove(Restaurant);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        
        
        
        }
        public IActionResult CommentDelete(int ID) 
        
        {
            var Comment= _dbContext.Comments.Where(c=>c.ID==ID).FirstOrDefault();
            _dbContext.Comments.Remove(Comment);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        
        }
        [HttpPost]
        public IActionResult search(string searchstring)
        {
            var restaurants = _dbContext.Restaurants.Where(r => r.Name.Contains(searchstring)).ToList();
            return (IActionResult)View(restaurants);
        }
    }
}
