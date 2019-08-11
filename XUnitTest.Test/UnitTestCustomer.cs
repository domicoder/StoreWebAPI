using PERSISTENCE;
using System;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Controllers;
using Xunit;

namespace XUnitTest.Test
{
    public class UnitTest1
    {
        StoreContext context;
        [Fact]
        public void Get_All_Customers()
        {
            // Act
            CustomerController customerController = new CustomerController(context);
            
            var result = customerController.GetCustomer();
            // Assert
            Assert.Single(result);
        }
    }
}