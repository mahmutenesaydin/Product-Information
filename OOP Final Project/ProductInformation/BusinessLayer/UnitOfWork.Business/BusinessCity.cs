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
    public class BusinessCity
    {
        private IRepository<City> _cityRepository;
        private IUnitOfWork _cityUnitOfWork;
        private DbContext _dbContext;

        public BusinessCity()
        {
            _dbContext = new ProductInformationEntities();
            _cityUnitOfWork = new EFUnitOfWork(_dbContext);
            _cityRepository = _cityUnitOfWork.GetRepository<City>();
        }

        public List<City> GetCities()
        {
            return _cityRepository.GetAll().ToList();
        }

        public void Add(City _city)
        {
            _cityRepository.Insert(_city);
            _cityUnitOfWork.SaveChanges();
        }

        public void Remove(int ID)
        {
            _cityRepository.Delete(ID);
            _cityUnitOfWork.SaveChanges();
        }

        public void Edit(City _city)
        {
            var city = _cityRepository.GetById(_city.CityID);

            city.CityName = _city.CityName;
            city.CountryID = _city.CountryID;
            _cityRepository.Update(city);
            _cityUnitOfWork.SaveChanges();
        }

        public City GetCity(int ID)
        {
            return _cityRepository.Get(c => c.CityID == ID);
        }

        private ProductInformationEntities db = new ProductInformationEntities();
        public List<City> ListForComboBox()
        {
            List<City> list = db.Cities.ToList();
            list.Insert(0, new City { CityID = 0, CityName= "Seçiniz..." });
            return list;
        }
    }
}
