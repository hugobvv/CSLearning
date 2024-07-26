using Microsoft.AspNetCore.Mvc;
using BibliothequeC_.Data;
using BibliothequeC_.Models;
using Microsoft.AspNetCore.Authorization;

namespace BibliothequeC_.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly BookDb _bookDbContext;
        private readonly UserDb _userDbContext;

        public HomeController(BookDb bookDbContext, UserDb userDbContext)
        {
            _bookDbContext = bookDbContext;
            _userDbContext = userDbContext;
        }

        public IActionResult Index()
        {
            var userName = User.Identity?.Name;
            var user = _userDbContext.Users.FirstOrDefault(u => u.Username == userName);

            if (user != null){
                return View(_bookDbContext.Books.ToList());
            }

            return View(new List<Book>());
        }
    }
}