using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStoreWebAPI
{
    [TestClass]
    public class UnitTestCustomer
    {
        [TestMethod]
        public void GetCustomerTest()
        {
            string Name = "Yander";
            string Lastname = "Sanchez";
            string Address = "Belen Segura";
            DateTime BornDate = new DateTime(1999, 02, 02);
            int PhoneNumber = 0000000000;
            string Email = "ta@gmail.com";
        }
    }
}
