using System.Linq;
using Microsoft.AspNetCore.Mvc;
using cs451_commerce_bank_project.Controllers.Concerns;
using cs451_commerce_bank_project.Models;

namespace cs451_commerce_bank_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDbContext db;

        public LoginController(AppDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User login)
        {
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
              return BadRequest();

            var user = db.Users.Where(a => a.Username == login.Username).FirstOrDefault();
            var passwordHash = Hashable.HashPassword(login.Password);

            if (user != null && passwordHash == user.Password)
                return Ok(user);
            else
                return BadRequest();
        }
    }
}
