using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;              

namespace SERVICES
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAll(Invoice model);
        bool Add(Invoice model);
        bool Update(Invoice model);
        bool Delete(int id);
        Invoice Get(int id);

    }

    public class InvoiceService : IInvoiceService
    {
        private readonly StoreContext _storeContext;

        public InvoiceService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<Invoice> GetAll(Invoice model)
        {
            var result = new List<Invoice>();
            try
            {
                result = _storeContext.Invoices.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public Invoice Get(int id)
        {
            var invoice = new Invoice();
            try
            {
                invoice = _storeContext.Invoices.Single(x => x.InvoiceId == id);
            }
            catch (System.Exception)
            {

            }
            return invoice;
        }

        public bool Add(Invoice model)
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

        public bool Update(Invoice model)
        {
            try
            {
                var originalModel = _storeContext.Invoices.Single(x =>
                x.InvoiceId == model.InvoiceId);

                originalModel.InvoiceId= model.InvoiceId;
                originalModel.CustomerId = model.CustomerId;
                
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
                _storeContext.Entry(new Category { CategoryId = id }).State = EntityState.Deleted;
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
