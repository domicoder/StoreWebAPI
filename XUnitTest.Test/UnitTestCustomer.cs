using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using Moq;
using PERSISTENCE;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Controllers;
using Xunit;

namespace XUnitTest.Test
{
    public class UnitTestCustomer
    {   
        public static DbContextOptions<StoreContext> storeContextOptions { get; }
        private static StoreContext _context;
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StoreWebApi;Trusted_Connection=True;ConnectRetryCount=0";

        static UnitTestCustomer()
        {
            storeContextOptions = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new StoreContext(storeContextOptions);
        }

        // -Init- Get BY ID
        [Fact]
        public async void Customer_GetCustomerById_Return_OkResult()
        {
            //Arrange  
            var controller = new CustomerController(_context);
            var customerId = 1;

            //Act  
            var data = await controller.GetCustomer(customerId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Customer_GetCustomerById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new CustomerController(_context);
            var customerId = 500;

            //Act  
            var data = await controller.GetCustomer(customerId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Customer_GetCustomerById_MatchResult()
        {
            //Arrange  
            var controller = new CustomerController(_context);
            int? customerId = 1;

            //Act  
            var data = await controller.GetCustomer(customerId.Value);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var customer = okResult.Value.Should().BeAssignableTo<Customer>().Subject;

            Assert.Equal("Yander", customer.Name);
            Assert.Equal(0, customer.PhoneNumber);
        }
        // -End- Get BY ID

        // -Init- Get ALL
        [Fact]
        public async void Customer_GetCustomers_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new CustomerController(_context);

            //Act  
            var customers = controller.GetCustomer();
            customers = null;

            if (customers != null)
                //Assert
                Assert.IsType<BadRequestResult>(customers);
        }
        // -End- Get BY ID

    }
}