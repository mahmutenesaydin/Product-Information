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
    public class BusinessUser
    {
        private IRepository<User> _userRepository;
        private IUnitOfWork _userUnitOfWork;
        private DbContext _dbContext;

        public BusinessUser()
        {
            _dbContext = new ProductInformationEntities();
            _userUnitOfWork = new EFUnitOfWork(_dbContext);
            _userRepository = _userUnitOfWork.GetRepository<User>();
        }

        public void Add(User _user)
        {
            _userRepository.Insert(_user);
            _userUnitOfWork.SaveChanges();
        }

        public void Edit(User _user)
        {
            var user = _userRepository.GetById(_user.UserID);
            user.FirstName = _user.FirstName;
            user.LastName = _user.LastName;
            user.UserName = _user.UserName;
            user.Password = _user.Password;
            user.PhoneNumber = _user.PhoneNumber;
            user.Gender = _user.Gender;
            user.Photo = _user.Photo;
            _userRepository.Update(user);
            _userUnitOfWork.SaveChanges();
        } 

        public List<User> GetCreditCarts()
        {
            return _userRepository.GetAll().ToList();
        }

        public void Remove(int ID)
        {
            _userRepository.Delete(ID);
            _userUnitOfWork.SaveChanges();
        }

        public User GetUser(int ID)
        {
            return _userRepository.Get(user => user.UserID== ID);
        }

    }
}
