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
    public class RulesController : Controller
    {
        private readonly AppDbContext db;

        public RulesController(AppDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<NotificationRule>> Index(int id)
        {
            var data = await db.NotificationRules.ToListAsync();
            return data.Where(item => item.UserId == id);
        }

        /**
        * Get data for a single notification rule.
        *
        * @param {int} id - Id for the rule to search for
        * @return {json} rule data
        */
        [HttpGet("single/{id}")]
        public async Task<NotificationRule> Single(int id)
        {
            var data = await db.NotificationRules.ToListAsync();
            return data.Where(item => item.Id == id).FirstOrDefault();
        }

        /**
        * Add a new notification rule.
        *
        * @param {json} rule - JSON object with data for new rule
        * @return {json} new rule data
        */
        [HttpPost]
        public async Task<NotificationRule> Create([FromBody] NotificationRule rule)
        {
            db.NotificationRules.Add(rule);
            await db.SaveChangesAsync();

            return rule;
        }

        /**
        * Update a notification rule.
        *
        * @param {json} rule - JSON object with data for update
        * @return {json} updated rule data
        */
        [HttpPut("{rule}")]
        public async Task<NotificationRule> Edit([FromBody] NotificationRule rule) {
            db.NotificationRules.Update(rule);
            await db.SaveChangesAsync();

            return rule;
        }

        /**
        * Delete a notification rule.
        *
        * @param {json} rule - JSON object with id for rule to remove
        * @return {json} removed rule info
        */
        [HttpDelete("{rule}")]
        public async Task<NotificationRule> Delete([FromBody] NotificationRule rule) {
            db.NotificationRules.Remove(rule);
            await db.SaveChangesAsync();

            return rule;
        }
    }
}
