using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cs451_commerce_bank_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cs451_commerce_bank_project.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TransactionController : Controller
  {
    private readonly AppDbContext db;

    public TransactionController(AppDbContext dbContext)
    {
      db = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Transaction>> Get(int? accountId)
    {
      var transactions = accountId == null ?
        await db.Transactions.OrderByDescending(p => p.ProcessingDate).ToListAsync() :
        await db.Transactions.Where(a => a.UserAccountId == accountId).OrderByDescending(p => p.ProcessingDate).ToListAsync();

      return transactions;
    }

    [HttpPost]
    public async Task<Transaction> Create([FromBody] Transaction transaction)
    {
      var user = await db.Users.Where(a => a.AccountId == transaction.UserAccountId).ToListAsync();
      var rules = await db.NotificationRules.Where(a => a.UserId == user[0].Id).ToListAsync();

      foreach (NotificationRule rule in rules)
      {
        bool isTriggered = false;

        switch (rule.Type)
        {
          case "Location":
            if (transaction.Location != rule.Location)
              isTriggered = true;
            break;
          case "Amount":
            if (transaction.Amount >= rule.AmountGreaterThan)
              isTriggered = true;
            break;
          case "Time":
            break;
        }

        if (isTriggered)
        {
          rule.CountTriggered += 1;
          db.NotificationRules.Update(rule);
        }
      }

      db.Transactions.Add(transaction);
      await db.SaveChangesAsync();

      return transaction;
    }
  }
}
