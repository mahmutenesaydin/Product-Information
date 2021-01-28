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
    public class BusinessShipper
    {
        private IRepository<Shipper> _shipperRepository;
        private IUnitOfWork _shipperUnitOfWork;
        private DbContext _dbContext;

        public BusinessShipper(DbContext dbContext)
        {
            _dbContext = new ProductInformationEntities();
            _shipperUnitOfWork = new EFUnitOfWork(_dbContext);
            _shipperRepository = _shipperUnitOfWork.GetRepository<Shipper>();
        }

        public List<Shipper> GetShippers()
        {
            return _shipperRepository.GetAll().ToList();
        }

        public void Add(Shipper _shipper)
        {
            _shipperRepository.Insert(_shipper);
            _shipperUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _shipperRepository.Delete(ID);
            _shipperUnitOfWork.SaveChanges();
        }

        public void Edit(Shipper _shipper)
        {
            var shipper = _shipperRepository.GetById(_shipper.ShipperID);

            shipper.CompanyName = _shipper.CompanyName;
            shipper.CompanyPhoneNumber = _shipper.CompanyPhoneNumber;
            _shipperRepository.Update(shipper);
            _shipperUnitOfWork.SaveChanges();
        }

        public Shipper GetShipper(int ID)
        {
            return _shipperRepository.Get(shipper => shipper.ShipperID == ID);
        }
    }
}
