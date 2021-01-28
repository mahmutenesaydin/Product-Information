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
    public class BusinessBrand
    {
        private ProductInformationEntities db = new ProductInformationEntities();
        private IRepository<Brands> _brandRepository;
        private IUnitOfWork _brandUnitOfWork;
        private DbContext _dbContext;

        public BusinessBrand()
        {
            _dbContext = new ProductInformationEntities();
            _brandUnitOfWork = new EFUnitOfWork(_dbContext);
            _brandRepository = _brandUnitOfWork.GetRepository<Brands>();
        }

        public List<Brands> GetBrands()
        {
            return _brandRepository.GetAll().ToList();
        }

        public List<Brands> ListForComboBox()
        {
            List<Brands> list = db.Brands1.ToList();
            list.Insert(0, new Brands { BrandID = 0, Brand= "Seçiniz..." });
            return list;
        }

        public void Add(Brands _brand)
        {
            _brandRepository.Insert(_brand);
            _brandUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _brandRepository.Delete(ID);
            _brandUnitOfWork.SaveChanges();
        }

        public void Edit(Brands _brand)
        {
            var brand = _brandRepository.GetById(_brand.BrandID);
            brand.Brand= _brand.Brand;
            _brandRepository.Update(brand);
            _brandUnitOfWork.SaveChanges();
        }

        public Brands GetBrand(int ID)
        {
            return _brandRepository.Get(b => b.BrandID == ID);
        }
    }
}
