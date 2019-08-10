using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICES
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Customer model);
        bool Add(Customer model);
        bool Update(Customer model);
        bool Delete(int id);
        Customer Get(int id);

    }
    public class CustomerService : ICustomerService
    {
        private readonly StoreContext _storeContext;

        public CustomerService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<Customer> GetAll(Customer model)
        {
            var result = new List<Customer>();
            try
            {
                result = _storeContext.Customers.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public Customer Get(int id)
        {
            var customer = new Customer();
            try
            {
                customer = _storeContext.Customers.Single(x => x.CustomerId == id);
            }
            catch (System.Exception)
            {

            }
            return customer;
        }

        public bool Add(Customer model)
        {
            try
            {
                _storeContext.Add(model);
                _storeContext.SaveChanges();

            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Customer model)
        {
            try
            {
                var originalModel = _storeContext.Customers.Single(x =>
                x.CustomerId == model.CustomerId);

                originalModel.Name = model.Name;
                originalModel.Lastname = model.Lastname;
                originalModel.Address = model.Address;
                originalModel.PhoneNumber = model.PhoneNumber;
                originalModel.Email = model.Email;

                _storeContext.Update(originalModel);
                _storeContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _storeContext.Entry(new Customer { CustomerId = id }).State = EntityState.Deleted;
                _storeContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
