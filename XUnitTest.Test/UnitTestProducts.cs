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
    public class UnitTestProducts
    {
        public static DbContextOptions<StoreContext> storeContextOptions { get; }
        private static StoreContext _context;
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StoreWebApi;Trusted_Connection=True;ConnectRetryCount=0";

        static UnitTestProducts()
        {
            storeContextOptions = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new StoreContext(storeContextOptions);
        }

        // -Init- Get BY ID
        [Fact]
        public async void Product_GetProductById_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductsController(_context);
            var productId = 1;

            //Act  
            var data = await controller.GetProduct(productId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Product_GetProductById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new ProductsController(_context);
            var productId = 500;

            //Act  
            var data = await controller.GetProduct(productId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Product_GetProductById_MatchResult()
        {
            //Arrange  
            var controller = new ProductsController(_context);
            int? productId = 1;

            //Act  
            var data = await controller.GetProduct(productId.Value);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var product = okResult.Value.Should().BeAssignableTo<Product>().Subject;

            Assert.Equal("Mouse", product.Name);
            Assert.Equal(10, product.Price);
            Assert.Equal(15, product.Stock);
        }
        // -End- Get BY ID

        // -Init- Get ALL
        [Fact]
        public async void Product_GetProducts_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new ProductsController(_context);

            //Act  
            var products = controller.GetProducts();
            products = null;

            if (products != null)
                //Assert
                Assert.IsType<BadRequestResult>(products);
        }
        // -End- Get BY ID

    }
}