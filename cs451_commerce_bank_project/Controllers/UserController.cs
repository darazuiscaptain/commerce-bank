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
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var users = await _dbContext.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            var item = await _dbContext.Users.FirstOrDefaultAsync(item => item.Id == id);

            return item;
        }

        [HttpPost]
        public async Task<int> Create([FromBody] User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, User user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);
            existingUser.Name = user.Name;
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.Users.FirstOrDefaultAsync(item => item.Id == id);
            _dbContext.Users.Remove(item);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}