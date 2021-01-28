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
    public class BusinessCustomer
    {
        private IRepository<Customer> _customerRepository;
        private IUnitOfWork _customerUnitOfWork;
        private DbContext _dbContext;

        public BusinessCustomer()
        {
            _dbContext = new ProductInformationEntities();
            _customerUnitOfWork = new EFUnitOfWork(_dbContext);
            _customerRepository = _customerUnitOfWork.GetRepository<Customer>();
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetAll().ToList();
        }

        public void Add(Customer _customer)
        {
            _customerRepository.Insert(_customer);
            _customerUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _customerRepository.Delete(ID);
            _customerUnitOfWork.SaveChanges();
        }

        public void Edit(Customer _customer)
        {
            var customer = _customerRepository.GetById(_customer.CustomerID);

            customer.FirstName = _customer.FirstName;
            customer.LastName = _customer.LastName;
            customer.PhoneNumber = _customer.PhoneNumber;
            customer.Selected = _customer.Selected;
            customer.UserID = _customer.UserID;
            _customerRepository.Update(customer);
            _customerUnitOfWork.SaveChanges();
        }

        public Customer GetCustomer(int ID)
        {
            return _customerRepository.Get(cus => cus.CustomerID == ID);
        }
    }
}
