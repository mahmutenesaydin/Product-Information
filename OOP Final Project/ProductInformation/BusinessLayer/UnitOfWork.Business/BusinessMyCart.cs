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
    class BusinessMyCart
    {
        private IRepository<MyCart> _myCartRepository;
        private IUnitOfWork _myCartUnitOfWork;
        private DbContext _dbContext;

        public BusinessMyCart(DbContext dbContext)
        {
            _dbContext = new ProductInformationEntities();
            _myCartUnitOfWork = new EFUnitOfWork(_dbContext);
            _myCartRepository = _myCartUnitOfWork.GetRepository<MyCart>();
        }

        public List<MyCart> GetMyCarts()
        {
            return _myCartRepository.GetAll().ToList();
        }

        public void Add(MyCart _myCart)
        {
            _myCartRepository.Insert(_myCart);
            _myCartUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _myCartRepository.Delete(ID);
            _myCartUnitOfWork.SaveChanges();
        }

        public void Edit(MyCart _myCart)
        {
            var myCart = _myCartRepository.GetById(_myCart.MyCartID);

            myCart.MyCart1 = _myCart.MyCart1;
            myCart.UnitPrice = _myCart.UnitPrice;
            myCart.ProductID = _myCart.ProductID;
            myCart.UserID = _myCart.UserID;
            myCart.OrderID = _myCart.OrderID;
            _myCartRepository.Update(myCart);
            _myCartUnitOfWork.SaveChanges();

        }

        public MyCart GetMyCart(int ID)
        {
            return _myCartRepository.Get(myCart => myCart.MyCartID == ID);
        }
    }
}
