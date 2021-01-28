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
    public class BusinessProduct
    {
        ProductInformationEntities db = new ProductInformationEntities();
        private IRepository<Product> _productRepository;
        private IUnitOfWork _productUnitOfWork;
        private DbContext _dbContext;

        public BusinessProduct()
        {
            _dbContext = new ProductInformationEntities();
            _productUnitOfWork = new EFUnitOfWork(_dbContext);
            _productRepository = _productUnitOfWork.GetRepository<Product>();
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public void Add(Product _product)
        {
            _productRepository.Insert(_product);
            _productUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _productRepository.Delete(ID);
            _productUnitOfWork.SaveChanges();
        }

        public void Edit(Product _product)
        {
            var prod = _productRepository.GetById(_product.ProductID);

            prod.CategoryID = _product.CategoryID;
            prod.ProductTypeID = _product.ProductTypeID; 
            prod.BrandID = _product.BrandID;
            prod.ModelID = _product.ModelID;
            prod.Price = _product.Price;
            prod.OutputYear = _product.OutputYear;
            prod.Color = _product.Color;
            prod.Stock = _product.Stock;
            prod.WarrantyPeriod = _product.WarrantyPeriod;
            prod.Photo1 = _product.Photo1;
            prod.Photo2 = _product.Photo2;
            _productRepository.Update(prod);
            _productUnitOfWork.SaveChanges();
        }

        public Product GetProduct(int ID)
        {
            return _productRepository.Get(prod => prod.ProductID == ID);
        }

        public List<SP_ProdStockByType_Result> ProductsStockByCategory()
        {
            return db.SP_ProdStockByType().ToList();
        }
    }
}
