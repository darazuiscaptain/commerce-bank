using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult Create([FromBody] User login)
        {
            var user = db.Users.Where(a => a.EmailAddress == login.EmailAddress).FirstOrDefault();

            return Redirect("http://localhost:8080/");
        }
    }
}
