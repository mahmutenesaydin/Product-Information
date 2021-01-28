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
    public class BusinessCreditCart
    {
        private IRepository<CreditCart> _creditRepository;
        private IUnitOfWork _creditUnitOfWork;
        private DbContext _dbContext;

        public BusinessCreditCart()
        {
            _dbContext = new ProductInformationEntities();
            _creditUnitOfWork = new EFUnitOfWork(_dbContext);
            _creditRepository = _creditUnitOfWork.GetRepository<CreditCart>();
        }

        public List<CreditCart> GetCreditCarts()
        {
            return _creditRepository.GetAll().ToList();
        }

        public void Add(CreditCart _creditcart)
        {
            _creditRepository.Insert(_creditcart);
            _creditUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _creditRepository.Delete(ID);
            _creditUnitOfWork.SaveChanges();
        }

        public void Edit(CreditCart _creditcart)
        {
            var creditCart = _creditRepository.GetById(_creditcart.CreditCartID);

            creditCart.CartOwner = _creditcart.CartOwner;
            creditCart.CardNumber = _creditcart.CardNumber;
            //creditCart.Limit = _creditcart.Limit;
            creditCart.Password = _creditcart.Password;
            creditCart.SecurityCode = _creditcart.SecurityCode;
            creditCart.CustomerID = _creditcart.CustomerID;
            _creditRepository.Update(creditCart);
            _creditUnitOfWork.SaveChanges();
        }

        public CreditCart GetCreditCart(int ID)
        {
            return _creditRepository.Get(cc => cc.CreditCartID == ID);
        }
    }
}
