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
    class BusinessSupplier
    {
        private IRepository<Supplier> _supplierRepository;
        private IUnitOfWork _supplierUnitOfWork;
        private DbContext _dbContext;

        public BusinessSupplier(DbContext dbContext)
        {
            _dbContext = new ProductInformationEntities();
            _supplierUnitOfWork = new EFUnitOfWork(_dbContext);
            _supplierRepository = _supplierUnitOfWork.GetRepository<Supplier>();
        }

        public List<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetAll().ToList();
        }

        public void Add(Supplier _supplier)
        {
            _supplierRepository.Insert(_supplier);
            _supplierUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _supplierRepository.Delete(ID);
            _supplierUnitOfWork.SaveChanges();
        }

        public void Edit(Supplier _supplier)
        {
            var supplier = _supplierRepository.GetById(_supplier.SupplierID);

            supplier.CompanyName = _supplier.CompanyName;
            supplier.PhoneNumber = _supplier.PhoneNumber;
            supplier.Address = _supplier.Address;
            _supplierRepository.Update(supplier);
            _supplierUnitOfWork.SaveChanges();
        }

        public Supplier GetSupplier(int ID)
        {
            return _supplierRepository.Get(supplier => supplier.SupplierID == ID);
        }
    }
}
