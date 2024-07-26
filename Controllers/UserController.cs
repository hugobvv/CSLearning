using Microsoft.AspNetCore.Mvc;
using BibliothequeC_.Data;
using BibliothequeC_.Models;

namespace BibliothequeC_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserDb _dbContext;

        public UserController(UserDb dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("Get")]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] User model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = "User"
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username);

                if (user != null && model.Password == user.Password)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        private string HashPassword(string password)
        {
            // Implementer une fonction de hachage sécurisée (SHA256, bcrypt, etc.)
            return password; // À remplacer par une vraie fonction de hachage sécurisée
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Implementer la vérification du mot de passe
            return password == passwordHash; // À remplacer par une vraie vérification sécurisée
        }
    }
}
