using cs451_commerce_bank_project.Controllers;
using cs451_commerce_bank_project.Models;
using cs451_commerce_bank_project.Controllers.Concerns;
using cs451_commerce_bank_project;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace cs451_commerce_bank_project.tests {
    public class UserControllerTests
    {
        //private UserController controller;
        private AppDbContext context;
        private DbContextOptions<DbContext> _contextOptions;
        public UserControllerTests() {
            _contextOptions = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase("UserTest")
            .Options;

            context = new AppDbContext(_contextOptions);

            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();

            context.Users.Add(new User() {
                Id = 1,
                AccountId = 100,
                Name = "john",
                Username = "john12",
                Password = Hashable.HashPassword("appleseed")
            });
            context.Users.Add(new User() {
                Id = 2,
                AccountId = 101,
                Name = "bob",
                Username = "bob90",
                Password = Hashable.HashPassword("orange")
            });
            context.SaveChanges();
            //controller = new UserController(context);
        }

        [Fact]
        public void getUsersTest()
        {
            UserController controller = new UserController(context);
            var result = controller.Get();
            Assert.NotNull(result.Result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void getUserByID(int id) {
            UserController controller = new UserController(context);
            var result = controller.Get(id);
            Assert.Equal(id, result.Result.Id);

        }
        // test PUT method
        [Fact]
        public void updateUser()
        {
            UserController controller = new UserController(context);
            // update name from "john" to "johnny"
            User user = new User() {
                Name = "johnny"
            };
            var result = controller.Update(1, user);
            Assert.Equal<bool>(true, result.Result);
        }
        [Fact]
        public async void createUserTest()
        {
            UserController controller = new UserController(context);
            var user = new User() {
                Id = 3,
                Name = "andy",
                Username = "andy50",
                Password = "banana"
            };
            var result = await controller.Create(user);
            Assert.IsType<User>(result);
        }
    }
}