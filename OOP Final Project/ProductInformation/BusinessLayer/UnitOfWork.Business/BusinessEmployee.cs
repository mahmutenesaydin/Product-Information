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
    public class BusinessEmployee
    {
        private IRepository<Employee> _employeeRepository;
        private IUnitOfWork _employeeUnitOfWork;
        private DbContext _dbContext;

        public BusinessEmployee()
        {
            _dbContext = new ProductInformationEntities();
            _employeeUnitOfWork = new EFUnitOfWork(_dbContext);
            _employeeRepository = _employeeUnitOfWork.GetRepository<Employee>();
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public void Add(Employee _employee)
        {
            _employeeRepository.Insert(_employee);
            _employeeUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _employeeRepository.Delete(ID);
            _employeeUnitOfWork.SaveChanges();
        }

        public void Edit(Employee _employee)
        {
            var emp = _employeeRepository.GetById(_employee.EmployeeID);
            emp.FirstName = _employee.FirstName;
            emp.LastName = _employee.LastName;
            emp.RoleOf = _employee.RoleOf;
            emp.PhoneNumber = _employee.PhoneNumber;
            emp.DateOfBirth = _employee.DateOfBirth;
            emp.DateOfStart = _employee.DateOfStart;
            emp.Address = _employee.Address;
            emp.Photo = _employee.Photo;
            _employeeRepository.Update(emp);
            _employeeUnitOfWork.SaveChanges();
        }

        public Employee GetEmployee(int ID)
        {
            return _employeeRepository.Get(emp => emp.EmployeeID== ID);
        }
    }
}
