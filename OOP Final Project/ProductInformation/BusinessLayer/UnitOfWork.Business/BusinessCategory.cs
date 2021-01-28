using BusinessLayer.Repository.Abstract;
using BusinessLayer.Repository.Concrete;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UnitOfWork.Business
{
    public class BusinessCategory
    {
        private ProductInformationEntities db = new ProductInformationEntities();
        private IRepository<Category> _categoryRepository;
        private IUnitOfWork _categoryUnitOfWork;
        private DbContext _dbContext;

        public BusinessCategory()
        {
            _dbContext = new ProductInformationEntities();
            _categoryUnitOfWork = new EFUnitOfWork(_dbContext);
            _categoryRepository = _categoryUnitOfWork.GetRepository<Category>();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public List<Category> ListForComboBox()
        {
            List<Category> list = db.Categories.ToList();
            list.Insert(0, new Category { CategoryID = 0, CategoryName = "Seçiniz..." });
            return list;
        }

        public void Add(Category _category)
        {
            _categoryRepository.Insert(_category);
            _categoryUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _categoryRepository.Delete(ID);
            _categoryUnitOfWork.SaveChanges();
        }

        public void Edit(Category _category)
        {
            var cat = _categoryRepository.GetById(_category.CategoryID);
            cat.CategoryName = _category.CategoryName;
            _categoryRepository.Update(cat);
            _categoryUnitOfWork.SaveChanges();
        }

        public Category GetCategory(int ID)
        {
            return _categoryRepository.Get(cat => cat.CategoryID == ID);
        }
    }
}
