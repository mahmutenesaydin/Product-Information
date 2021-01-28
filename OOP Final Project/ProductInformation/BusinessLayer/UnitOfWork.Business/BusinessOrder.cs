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
    public class BusinessOrder
    {
        private IRepository<Order> _orderRepository;
        private IUnitOfWork _orderUnitOfWork;
        private DbContext _dbContext;

        public BusinessOrder()
        {
            _dbContext = new ProductInformationEntities();
            _orderUnitOfWork = new EFUnitOfWork(_dbContext);
            _orderRepository = _orderUnitOfWork.GetRepository<Order>();
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public void Add(Order _order)
        {
            _orderRepository.Insert(_order);
            _orderUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _orderRepository.Delete(ID);
            _orderUnitOfWork.SaveChanges();
        }

        public void Edit(Order _order)
        {
            var order = _orderRepository.GetById(_order.OrderID);

            order.Address = _order.Address;
            order.ProductCode = _order.ProductCode;
            order.CategoryID = _order.CategoryID;
            order.TypeID = _order.TypeID;
            order.ProductID = _order.ProductID;
            order.BrandID = _order.BrandID;
            order.ModelID = _order.ModelID;
            order.CountryID = _order.CountryID;
            order.CityID = _order.CityID;
            order.ShipperID = _order.ShipperID;
            _orderRepository.Update(order);
            _orderUnitOfWork.SaveChanges();
        }

        public Order GetOrder(int ID)
        {
            return _orderRepository.Get(order => order.OrderID == ID);
        }
    }
}
