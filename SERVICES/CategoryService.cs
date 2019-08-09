using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICES
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll(Category model);
        bool Add(Category model);
        bool Update(Category model);
        bool Delete(int id);
        Category Get(int id);

    }

    public class CategoryService : ICategoryService
    {
        private readonly StoreContext _storeContext;

        public CategoryService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<Category> GetAll(Category model)
        {
            var result = new List<Category>();
            try
            {
                result = _storeContext.Categories.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public Category Get(int id)
        {
            var category = new Category();
            try
            {
                category = _storeContext.Categories.Single(x => x.CategoryId == id);
            }
            catch (System.Exception)
            {

            }
            return category;
        }

        public bool Add(Category model)
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

        public bool Update(Category model)
        {
            try
            {
                var originalModel = _storeContext.Categories.Single(x =>
                x.CategoryId == model.CategoryId);

                originalModel.Name = model.Name;
                originalModel.Description = model.Description;

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
