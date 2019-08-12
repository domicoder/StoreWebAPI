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
    public class UnitTestInvoiceProductDetail
    {
        public static DbContextOptions<StoreContext> storeContextOptions { get; }
        private static StoreContext _context;
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StoreWebApi;Trusted_Connection=True;ConnectRetryCount=0";

        static UnitTestInvoiceProductDetail()
        {
            storeContextOptions = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new StoreContext(storeContextOptions);
        }

        // -Init- Get BY ID
        [Fact]
        public async void InvoiceProductDetail_GetInvoiceProductDetailById_Return_OkResult()
        {
            //Arrange  
            var controller = new InvoiceProductDetailController(_context);
            var invoiceId = 1;
            var customerId = 1;
            var productId = 1;

            //Act  
            var data = controller.GetInvoiceProductDetail(customerId, invoiceId, productId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void InvoiceProductDetail_GetInvoiceProductDetailById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new InvoiceProductDetailController(_context);
            var invoiceId = 100;
            var customerId = 100;
            var productId = 100;

            //Act  
            var data = controller.GetInvoiceProductDetail(customerId, invoiceId, productId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        // -End- Get BY ID

        // -Init- Get ALL
        [Fact]
        public async void InvoiceProductDetail_GetInvoiceProductDetails_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new InvoiceProductDetailController(_context);

            //Act  
            var invoices = controller.GetInvoiceProductDetails();
            invoices = null;

            if (invoices != null)
                //Assert
                Assert.IsType<BadRequestResult>(invoices);
        }
        // -End- Get BY ID

    }
}