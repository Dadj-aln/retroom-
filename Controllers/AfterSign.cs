using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using retroom_last.Models;

namespace retroom_last.Controllers
{
    public class AfterSignController : Controller
    {
        private readonly RetrooomDbContext _dbContext;

        public AfterSignController(RetrooomDbContext dbContext)
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
        public IActionResult FullSpecs(int ID)

        {





            var restaurant = _dbContext.Restaurants.Where(r => r.ID == ID).FirstOrDefault();
            var comments = _dbContext.Comments.Include(c => c.Person).Where(c => c.RestaurantID == ID).ToList();

            var restaurantcommentviewmodel = new RestaurantCommentViewModel(restaurant, comments);
            TempData["RID"] = restaurantcommentviewmodel.restaurant.ID;
            return View(restaurantcommentviewmodel);

        }
        public IActionResult CommentSubmit()
        {



            return View();
        }

        [HttpPost]
        public IActionResult CommentProcess(Comment comment)
        {






            comment.CommentContent = comment.CommentContent;
            comment.Taste = comment.Taste;
            comment.Quality = comment.Quality;
            comment.Clean = comment.Clean;
            comment.PriceWorth = comment.PriceWorth;
            comment.PersonID = (int)TempData["UserID"];
            comment.RestaurantID = (int)TempData["RID"];

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();

            return RedirectToAction("index", "AfterSign");




        }

        public IActionResult RestaurantRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RestaurantProcess(Restaurant model)
        {
            try
            {
                

                // Handle file upload
                string ImageBase64 = "";
                using (var ms = new MemoryStream())
                {
                    model.ImageFile.CopyTo(ms);
                    byte[] FileBytes = ms.ToArray();
                    ImageBase64 = Convert.ToBase64String(FileBytes);
                }
                string image = String.Format("data:image/png;base64,{0}", ImageBase64);
                model.ImagePath= image;
                model.PersonID = (int)TempData["UID"];
                _dbContext.Restaurants.Add(model);
                _dbContext.SaveChanges();


                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult search(string searchstring)
        {
            var restaurants = _dbContext.Restaurants.Where(r => r.Name.Contains(searchstring)).ToList();
            return (IActionResult)View(restaurants);
        }

    }
}
