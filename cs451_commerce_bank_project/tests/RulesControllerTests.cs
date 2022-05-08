using System;
using System.Linq;
using cs451_commerce_bank_project;
using cs451_commerce_bank_project.Controllers;
using cs451_commerce_bank_project.Models;
using cs451_commerce_bank_project.Controllers.Concerns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace cs451_commerce_bank_project.tests {
    public class RulesControllerTests
    {
        //private RulesController controller;
        private AppDbContext context;
        private DbContextOptions<DbContext> _contextOption;
        public RulesControllerTests() {
            _contextOption = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase("RulesTest")
            .Options;

            context = new AppDbContext(_contextOption);
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
            context.Users.Add(new User() {
                Id = 1,
                AccountId = 1,
                Name = "john",
                Username = "john12",
                Password = Hashable.HashPassword("appleseed")
            });
            context.NotificationRules.Add(new NotificationRule() {
                Id = 1,
                UserId = 1,
                Name = "",
                Type = "",
                StartTime = new DateTime(2022, 10, 12),
                EndTime = new DateTime(2022, 11, 2),
                Location = "MO",
                AmountGreaterThan = 100,
                CountTriggered = 1
            });
            context.NotificationRules.Add(new NotificationRule() {
                Id = 2,
                UserId = 1,
                Name = "",
                Type = "",
                StartTime = new DateTime(2022, 9, 9),
                EndTime = new DateTime(2022, 10, 1),
                Location = "KS",
                AmountEquals = 150,
                CountTriggered = 0
            });
            context.SaveChanges();
            //controller = new RulesController(context);
        }

        [Fact]
        public void TestIndex()
        {
            RulesController controller = new RulesController(context);
            var result = controller.Index(1); // id = 1
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void TestGetSingleRule()
        {
            RulesController controller = new RulesController(context);
            var result = controller.Single(1);
            Assert.Equal<int>(1, result.Result.Id);
        }
        [Fact]
        public void TestAddRule()
        {
            RulesController controller = new RulesController(context);
            var result = controller.Create(new NotificationRule() {});
            Assert.IsType<NotificationRule>(result.Result);
        }

        [Fact]
        public async void TestUpdateRule()
        {
            RulesController controller = new RulesController(context);

            NotificationRule rule = context.Set<NotificationRule>()
            .Local
            .FirstOrDefault(r => r.Id.Equals(2));

            if (rule != null) {
                context.Entry(rule).State = EntityState.Modified;
            }

            rule.CountTriggered = 2;
            /*
            NotificationRule rule = new NotificationRule() {
                Id = 2,
                UserId = 1,
                Name = "",
                Type = "",
                StartTime = new DateTime(2022, 10, 12),
                EndTime = new DateTime(2022, 11, 2),
                Location = "KS",
                AmountGreaterThan = 100,
                CountTriggered = 1
            };*/

            var result = await controller.Edit(rule);
            context.Entry(result).State = EntityState.Modified;
            context.SaveChanges();
            Assert.Equal<int>(2, result.CountTriggered);
        }

        [Fact]
        public async void TestDeleteRule()
        {
            
            RulesController controller = new RulesController(context);

            NotificationRule rule = context.Set<NotificationRule>()
            .Local
            .FirstOrDefault(r => r.Id.Equals(1));

            if (rule != null) {
                context.Entry(rule).State = EntityState.Detached;
            }
            //context.Entry(rule).State = EntityState.Modified;
            /*
            NotificationRule rule = new NotificationRule() {
                Id = 1
            };
            */
            var result = await controller.Delete(rule);

            context.Entry(result).State = EntityState.Modified;
            Assert.IsType<NotificationRule>(result);
        }
    }
}