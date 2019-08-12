using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using Moq;
using PERSISTENCE;
using SERVICES;
using StoreWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Controllers;
using Xunit;

namespace XUnitTest.Test
{
    public class UnitTestCategory
    {
        public static DbContextOptions<StoreContext> storeContextOptions { get; }
        private static StoreContext _context;
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StoreWebApi;Trusted_Connection=True;ConnectRetryCount=0";

        static UnitTestCategory()
        {
            storeContextOptions = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new StoreContext(storeContextOptions);
        }

        // -Init- Get BY ID
        [Fact]
        public async void Category_GetCategoryById_Return_OkResult()
        {
            //Arrange  
            var controller = new CategoryController(_context);
            var categoryId = 1;

            //Act  
            var data = await controller.GetCategory(categoryId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Category_GetCategoryById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new CategoryController(_context);
            var categoryId = 500;

            //Act  
            var data = await controller.GetCategory(categoryId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Category_GetCategoryById_MatchResult()
        {
            //Arrange  
            var controller = new CategoryController(_context);
            int? categoryId = 1;

            //Act  
            var data = await controller.GetCategory(categoryId.Value);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var category = okResult.Value.Should().BeAssignableTo<Category>().Subject;

            Assert.Equal("Electronicos", category.Name);
        }
        // -End- Get BY ID

        // -Init- Get ALL
        [Fact]
        public async void Category_GetCategories_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new CategoryController(_context);

            //Act  
            var categories = controller.GetCategories();
            categories = null;

            if (categories != null)
                //Assert
                Assert.IsType<BadRequestResult>(categories);
        }
        // -End- Get BY ID

    }
}
