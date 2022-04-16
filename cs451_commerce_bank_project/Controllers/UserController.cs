using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cs451_commerce_bank_project.Controllers.Concerns;
using cs451_commerce_bank_project.Models;

namespace cs451_commerce_bank_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext db;

        public UserController(AppDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var users = await db.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            var item = await db.Users.FirstOrDefaultAsync(item => item.Id == id);

            return item;
        }

        [HttpPost]
        public async Task<User> Create([FromBody] User user)
        {
            // Generate user's account ID
            Random rand = new Random();
            int accountId = rand.Next(1, 1000000000);
            user.AccountId = accountId;

            // Hash the user's entered password
            var passwordHash = Hashable.HashPassword(user.Password);
            user.Password = passwordHash;

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return user;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, User user)
        {
            var existingUser = await db.Users.FirstOrDefaultAsync(i => i.Id == id);
            existingUser.Name = user.Name;
            var result = await db.SaveChangesAsync();

            return result > 0;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await db.Users.FirstOrDefaultAsync(item => item.Id == id);
            db.Users.Remove(item);
            var result = await db.SaveChangesAsync();

            return result > 0;
        }
    }
}