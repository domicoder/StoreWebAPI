using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICES
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll(Product model);
        bool Add(Product model);
        bool Update(Product model);
        bool Delete(int id);
        Product Get(int id);

    }

    public class ProductService : IProductService
    {
        private readonly StoreContext _storeContext;

        public ProductService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<Product> GetAll(Product model)
        {
            var result = new List<Product>();
            try
            {
                result = _storeContext.Products.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public Product Get(int id)
        {
            var product = new Product();
            try
            {
                product = _storeContext.Products.Single(x => x.ProductId == id);
            }
            catch (System.Exception)
            {

            }
            return product;
        }

        public bool Add(Product model)
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

        public bool Update(Product model)
        {
            try
            {
                var originalModel = _storeContext.Products.Single(x =>
                x.ProductId == model.ProductId);

                originalModel.Name = model.Name;
                originalModel.Price = model.Price;
                originalModel.Stock= model.Stock;

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
                _storeContext.Entry(new Product { ProductId = id }).State = EntityState.Deleted;
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
