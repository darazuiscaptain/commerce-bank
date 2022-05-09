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
    public class LoginControllerTests
    {
        //private LoginController controller;
        private DbContextOptions<DbContext> _contextOptions;
        private AppDbContext context;
        public LoginControllerTests() {
            _contextOptions = new DbContextOptionsBuilder<DbContext>()
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .UseInMemoryDatabase("LoginTest")
            .Options;

            //using var context = new AppDbContext(_contextOptions);
            context = new AppDbContext(_contextOptions);
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();

            context.Users.Add(new User() {
                Id=1,
                AccountId = 100,
                Name="john",
                Username="john12",
                Password=Hashable.HashPassword("appleseed")
            });

            context.SaveChanges();
            //controller = new LoginController(context);
        }

        [Fact]
        public void UserLoginSuccessTest()
        {
            LoginController controller = new LoginController(context);
            var login = new User() {
                Username = "john12",
                Password = "appleseed"
            };
            var result = controller.Create(login);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void UserLoginFail()
        {
            LoginController controller = new LoginController(context);
            var login = new User() {
                Username = "DoesNotExist",
                Password = "banana12"
            };
            var result = controller.Create(login);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}