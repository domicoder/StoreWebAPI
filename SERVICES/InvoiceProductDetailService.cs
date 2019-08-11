using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICES
{
     public interface IInvoiceProductDetailService
    {
        IEnumerable<InvoiceProductDetail> GetAll(InvoiceProductDetail model);
        bool Add(InvoiceProductDetail model);
        bool Update(InvoiceProductDetail model);
        bool Delete(int id);
        InvoiceProductDetail Get(int id);

    }

    public class InvoiceProductDetailService : IInvoiceProductDetailService
    {
        private readonly StoreContext _storeContext;

        public InvoiceProductDetailService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<InvoiceProductDetail> GetAll(InvoiceProductDetail model)
        {
            var result = new List<InvoiceProductDetail>();
            try
            {
                result = _storeContext.InvoiceProductDetails.ToList();
            }
            catch (System.Exception)
            {
               
            }
            return result;
        }

        public InvoiceProductDetail Get(int id)
        {
            var invoice = new InvoiceProductDetail();
            try
            {
            }
            catch (System.Exception)
            {

            }
            return invoice;
        }

        public bool Add(InvoiceProductDetail model)
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

        public bool Update(InvoiceProductDetail model)
        {
            try
            {
            
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
