using System;
using System.Linq;
using cs451_commerce_bank_project.Controllers;
using cs451_commerce_bank_project.Models;
using cs451_commerce_bank_project.Controllers.Concerns;
using cs451_commerce_bank_project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace cs451_commerce_bank_project.tests {
    public class TransactionControllerTests
    {
        //private TransactionController controller;
        private AppDbContext context;
        private DbContextOptions<DbContext> _contextOptions;
        public TransactionControllerTests() {
            _contextOptions = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase("TransactionTest")
            .Options;

            context = new AppDbContext(_contextOptions);

            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();

            context.Users.Add(new User() {
                Id = 1,
                AccountId = 100,
                Name = "John",
                Username = "john12",
                Password = Hashable.HashPassword("appleseed")
            });
            context.Transactions.Add(new Transaction() {
                Id = 1,
                UserAccountId = 100,
                ProcessingDate = new DateTime(2022, 2, 4),
                Balance = 200,
                Type = "CR",
                Location = "MO",
                Description = "Town Topic"
            });
            context.Transactions.Add(new Transaction() {
                Id = 2,
                UserAccountId = 100,
                ProcessingDate = new DateTime(2022, 2, 4),
                Balance = 150,
                Type = "DR",
                Location = "KS",
                Description = "Walmart"
            });
            context.NotificationRules.Add(new NotificationRule() {
                Id = 1,
                UserId = 1,
                Name = "",
                Type = "Location",
                StartTime = new DateTime(2022, 10, 12),
                EndTime = new DateTime(2022, 11, 2),
                Location = "MO",
                AmountGreaterThan = 100,
                CountTriggered = 1
            });
            context.SaveChanges();
            //controller = new TransactionController(context);
        }

        [Fact]
        public async void TestGetbyAccountID()
        {
            TransactionController controller = new TransactionController(context);
            var result = await controller.Get(100);
            Assert.NotEmpty(result);
            Assert.Equal<int>(2, result.Count());
        }

        [Fact]
        public async void TestCreateTransaction()
        {
            TransactionController controller = new TransactionController(context);
            var result = await controller.Create(new Transaction() {
                Id = 3,
                UserAccountId = 100,
                ProcessingDate = new DateTime(2022, 2, 5),
                Balance = 100,
                Type = "DR",
                Location = "KS",
                Description = "McDonald's"

            });
            Assert.IsType<Transaction>(result);
        }
        
        [Fact]
        public async void TestNotificationRuleTrigger()
        {
            TransactionController controller = new TransactionController(context);
            var result = await controller.Create(new Transaction() {
                Id = 4,
                UserAccountId = 100,
                ProcessingDate = new DateTime(2022, 10, 13),
                Balance = 150,
                Type = "DR",
                Location = "KS",
                Description = "Stuff"
            });
            NotificationRule rule = context.NotificationRules.FirstOrDefault(r => r.Id.Equals(1));
            // if the notification rule has been triggered
            // then CountTrigger should have been incremented by 1
            Assert.Equal<int>(2, rule.CountTriggered);
        }
    }
}