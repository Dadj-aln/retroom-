using Microsoft.AspNetCore.Mvc;
using retroom_last.Models;

namespace retroom_last.ViewComponents
{
    [ViewComponent(Name = "UserInfo")]
    public class UserInfo : ViewComponent
    {
        private readonly RetrooomDbContext _dbContext;
        public UserInfo(RetrooomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()

        {
          
                var person = _dbContext.People.Where(p => p.ID == (int)TempData["UID"]).FirstOrDefault();
                TempData["UserID"] = person.ID;

                return View(person);

            
            
        }
    }
}
