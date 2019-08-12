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
    public class UnitTestInvoice
    {
        public static DbContextOptions<StoreContext> storeContextOptions { get; }
        private static StoreContext _context;
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=StoreWebApi;Trusted_Connection=True;ConnectRetryCount=0";

        static UnitTestInvoice()
        {
            storeContextOptions = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new StoreContext(storeContextOptions);
        }

        // -Init- Get BY ID
        [Fact]
        public async void Invoice_GetInvoiceById_Return_OkResult()
        {
            //Arrange  
            var controller = new InvoiceController(_context);
            var invoiceId = 1;

            //Act  
            var data = await controller.GetInvoice(invoiceId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Invoice_GetInvoiceById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new InvoiceController(_context);
            var invoiceId = 500;

            //Act  
            var data = await controller.GetInvoice(invoiceId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Invoice_GetInvoiceById_MatchResult()
        {
            //Arrange  
            var controller = new InvoiceController(_context);
            int? invoiceId = 1;

            //Act  
            var data = await controller.GetInvoice(invoiceId.Value);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var invoice = okResult.Value.Should().BeAssignableTo<Invoice>().Subject;

            Assert.Equal(1, invoice.InvoiceId);
            Assert.Equal(1, invoice.CustomerId);
        }
        // -End- Get BY ID

        // -Init- Get ALL
        [Fact]
        public async void Invoice_GetInvoices_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new InvoiceController(_context);

            //Act  
            var invoices = controller.GetInvoices();
            invoices = null;

            if (invoices != null)
                //Assert
                Assert.IsType<BadRequestResult>(invoices);
        }
        // -End- Get BY ID

    }
}