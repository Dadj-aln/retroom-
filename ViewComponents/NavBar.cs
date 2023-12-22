using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using retroom_last.Controllers;
using retroom_last.Models;
using System.Linq;

namespace retroom_last.ViewComponents
{
    [ViewComponent(Name = "NavBar")]
    public class NavBar : ViewComponent
    {
        private readonly RetrooomDbContext _dbContext;
        public NavBar(RetrooomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public IViewComponentResult Invoke()
        {
            
            
            return View();
        }

        
    }
}
