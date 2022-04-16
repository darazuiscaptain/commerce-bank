using System;
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
        await db.Transactions.ToListAsync() :
        await db.Transactions.Where(a => a.UserAccountId == accountId).ToListAsync();

      return transactions;
    }

    [HttpPost]
    public async Task<Transaction> Create([FromBody] Transaction transaction)
    {
      db.Transactions.Add(transaction);
      await db.SaveChangesAsync();

      return transaction;
    }
  }
}
