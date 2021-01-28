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
    public class BusinessProductType
    { 
        private IRepository<ProductTypes> _productTypeRepository;
        private IUnitOfWork _productTypeUnitOfWork;
        private DbContext _dbContext;

        public BusinessProductType()
        {
            _dbContext = new ProductInformationEntities();
            _productTypeUnitOfWork = new EFUnitOfWork(_dbContext);
            _productTypeRepository = _productTypeUnitOfWork.GetRepository<ProductTypes>();
        }

        public List<ProductTypes> GetProductTypes()
        {
            return _productTypeRepository.GetAll().ToList();
        }

        public void Add(ProductTypes _productType)
        {
            _productTypeRepository.Insert(_productType);
            _productTypeUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _productTypeRepository.Delete(ID);
            _productTypeUnitOfWork.SaveChanges();
        }

        public void Edit(ProductTypes _productType)
        {
            var productType = _productTypeRepository.GetById(_productType.TypeID);

            productType.ProductType = _productType.ProductType;
            productType.CategoryID = _productType.CategoryID;
            _productTypeRepository.Update(productType);
            _productTypeUnitOfWork.SaveChanges();
        }

        public ProductTypes GetProductType(int ID)
        {
            return _productTypeRepository.Get(prodType => prodType.TypeID == ID);
        }


        private ProductInformationEntities db = new ProductInformationEntities();
        public List<ProductTypes> ListForComboBox()
        {
            List<ProductTypes> list = db.ProductTypes1.ToList();
            list.Insert(0, new ProductTypes { TypeID = 0, ProductType= "Seçiniz..." });
            return list;
        }
    }
}
